package docker_monitor.DM_app.process.database.repository;

import docker_monitor.DM_app.process.database.entities.Container;
import docker_monitor.DM_app.process.database.object.SampledBy;
import docker_monitor.DM_app.process.database.persistance.anotation.Aggregable;
import docker_monitor.DM_app.process.database.persistance.anotation.Column;
import docker_monitor.DM_app.process.database.persistance.anotation.Entity;
import docker_monitor.DM_app.process.database.persistance.anotation.Symbol;
import docker_monitor.DM_app.process.database.persistance.repository.QuestDBRepositoryImp;

import java.lang.annotation.Annotation;
import java.lang.reflect.Field;
import java.text.SimpleDateFormat;
import java.time.Instant;
import java.util.Arrays;
import java.util.Date;
import java.util.Iterator;
import java.util.List;
import java.util.stream.Collectors;

public class MetricsRepository<C> extends QuestDBRepositoryImp<C> {
    private final Class<C> clazz;

    public MetricsRepository(Class<C> clazz) {
        super(clazz);
        this.clazz = clazz;
    }

    private String averageOfAll(){
        StringBuilder result = new StringBuilder();
        Iterator<Field> fieldIterator = Arrays.stream(clazz.getDeclaredFields()).iterator();

        while (fieldIterator.hasNext()) {
            Field f = fieldIterator.next();
            if (f.getAnnotation(Aggregable.class) != null) {
                result.append(",")
                        .append("avg(")
                        .append(f.getAnnotation(Column.class).name())
                        .append(") ")
                        .append(f.getAnnotation(Column.class).name());
            }
        }
        return result.toString();
    }
    private String zeroOfAll(){
        StringBuilder result = new StringBuilder();
        Iterator<Field> fieldIterator = Arrays.stream(clazz.getDeclaredFields()).iterator();

        while (fieldIterator.hasNext()) {
            Field f = fieldIterator.next();
            if (f.getAnnotation(Aggregable.class) != null) {
                result.append(",")
                        .append("0L")
                        .append(" as ")
                        .append(f.getAnnotation(Column.class).name());
            }
        }
        return result.toString();
    }
    private String aggregableParams(){
        StringBuilder result = new StringBuilder();
        Iterator<Field> fieldIterator = Arrays.stream(clazz.getDeclaredFields()).iterator();

        while (fieldIterator.hasNext()) {
            Field f = fieldIterator.next();
            if (f.getAnnotation(Aggregable.class) != null) {
                result.append(",")
                        .append(f.getAnnotation(Column.class).name());
            }
        }
        return result.toString();
    }
    private String fillOption(){
        StringBuilder result = new StringBuilder();
        Iterator<Field> fieldIterator = Arrays.stream(clazz.getDeclaredFields()).iterator();
        String prefix = "";

        while (fieldIterator.hasNext()) {
            Field f = fieldIterator.next();
            if (f.getAnnotation(Aggregable.class) != null) {
                result.append(prefix);
                result.append("0");
                prefix = ",";
            }
        }
        return result.toString();
    }
    public List<C> findByContainerAndTime(String containerId, long dateTime) {
        SimpleDateFormat dateFormat = new SimpleDateFormat("yyyy-MM-dd HH:mm:ss.z");
        return executeQuery("SELECT * FROM " + clazz.getAnnotation(Entity.class).name() +
                " WHERE Container_id=" + "'" + containerId + "'" +" and date_time >=" + "to_timestamp('" + dateFormat.format(dateTime) + "','yyyy-MM-dd HH:mm:ss.z')");
    }
    public List<C> findByContainerAndTime(String containerId, long dateTime, SampledBy sampled) {
        SimpleDateFormat dateFormat = new SimpleDateFormat("yyyy-MM-dd HH:mm:ss.z");

        String query = "SELECT date_time, Container_id "+ averageOfAll() +" FROM ( " +
                " SELECT to_timestamp('" + dateFormat.format(dateTime) + "','yyyy-MM-dd HH:mm:ss.z') AS date_time, " +
                " symbol "+ "'" + containerId + "'" +" as  Container_id " +
                "" +  zeroOfAll() + " union "
                + "SELECT date_time, Container_id "+ aggregableParams() + "  FROM " + clazz.getAnnotation(Entity.class).name() +
                " WHERE Container_id=" + "'" + containerId + "'" +" and " +
                "date_time >=" + "to_timestamp('" + dateFormat.format(dateTime) + "','yyyy-MM-dd HH:mm:ss.z') union " +
                " SELECT to_timestamp('" + dateFormat.format(Instant.now().toEpochMilli()) + "','yyyy-MM-dd HH:mm:ss.z') AS date_time, " +
                "  symbol "+ "'" + containerId + "'" +" as  Container_id " +
                "" +  zeroOfAll() + ") timestamp(date_time) " +
                "SAMPLE BY " + sampled + " FILL("+fillOption()+")";
        return executeQuery(query);
    }
    public List<C> findByContainerAndRange(String containerId, long dateTimeFrom, long dateTomeTo){
        SimpleDateFormat dateFormat = new SimpleDateFormat("yyyy-MM-dd HH:mm:ss.z");
        return executeQuery("SELECT * FROM " + clazz.getAnnotation(Entity.class).name() +
                " WHERE Container_id=" + "'" + containerId + "'" +" and date_time >= " + "to_timestamp('" + dateFormat.format(dateTimeFrom) + "','yyyy-MM-dd HH:mm:ss.z')" +
                " and date_time <= " + "to_timestamp('" + dateFormat.format(dateTomeTo) + "','yyyy-MM-dd HH:mm:ss.z')");
    }
    public List<C> findByContainerAndRange(String containerId, long dateTimeFrom, long dateTomeTo, SampledBy sampled){
        SimpleDateFormat dateFormat = new SimpleDateFormat("yyyy-MM-dd HH:mm:ss.z");
        String query = "SELECT Container_id, date_time "+ averageOfAll() +" FROM " + clazz.getAnnotation(Entity.class).name() +
                " WHERE Container_id=" + "'" + containerId + "'" +" and date_time >= " + "to_timestamp('" + dateFormat.format(dateTimeFrom) + "','yyyy-MM-dd HH:mm:ss.z')" +
                " and date_time <= " + "to_timestamp('" + dateFormat.format(dateTomeTo) + "','yyyy-MM-dd HH:mm:ss.z')" +
                " SAMPLE BY " + sampled + " ";
                List<C> result = executeQuery( query + "FILL("+fillOption()+")");
        return result.size() != 0 ? result : executeQuery( query + "FILL(NONE)");
    }
    public void deleteData(long dateTimeTo){
        SimpleDateFormat dateFormat = new SimpleDateFormat("yyyy-MM-dd HH:mm:ss.z");
        executeQuery("ALTER TABLE " + clazz.getAnnotation(Entity.class).name() +" DROP PARTITION WHERE " +
                "date_time <" + " to_timestamp('" + dateFormat.format(dateTimeTo) + "','yyyy-MM-dd HH:mm:ss.z')");
    }
}
