package docker_monitor.DM_app.process.database.db_mapper;


import docker_monitor.DM_app.process.database.entities.Container;
import docker_monitor.DM_app.process.database.persistance.anotation.Column;
import docker_monitor.DM_app.process.sql.CustomResultSet;
import org.springframework.stereotype.Service;

import java.lang.reflect.*;
import java.time.Instant;
import java.util.Date;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.ArrayList;
import java.util.Iterator;
import java.util.List;


@Service
public class QuestDBDataMapperImp implements QuestDBDataMapper {
    private class FieldIndex{
        public FieldIndex(int index, Field field){
            this.filed = field;
            this.index = index;
        }
        public int index;
        public Field filed;
    }
    @Override
    public <C> List<C> mapResultSet(CustomResultSet resultSet, Class<C> clazz) throws SQLException {
        ArrayList<FieldIndex> fieldIndices = new ArrayList<>();
        for (Field f: clazz.getDeclaredFields()) {
            Column column = f.getAnnotation(Column.class);
            try{
                int index = resultSet.findColumn(column.name());
                fieldIndices.add(new FieldIndex(index, f));
            }
            catch(SQLException ignored){
            }
        }
        try {
            Constructor[] ctors = clazz.getDeclaredConstructors();
            Constructor ctor = null;
            for (int i = 0; i < ctors.length; i++) {
                ctor = ctors[i];
                if (ctor.getGenericParameterTypes().length == 0)
                    break;
            }
            ArrayList<C> result = new ArrayList<>();
            while(resultSet.next()) {
                ctor.setAccessible(true);
                C cc = (C)ctor.newInstance();
                for(FieldIndex index : fieldIndices){
                    index.filed.setAccessible(true);
                    Class<?> fieldType = index.filed.getType();
                    Method resultSetMethod = resultSetMethodResolver(fieldType);
                    index.filed.set(cc, resultSetMethod.invoke(resultSet,index.index));
                }
                result.add(cc);
            }
            return result;
        }
        catch ( NoSuchMethodException e){
            e.printStackTrace();
        } catch (InvocationTargetException e) {
            e.printStackTrace();
        } catch (InstantiationException e) {
            e.printStackTrace();
        } catch (IllegalAccessException e) {
            e.printStackTrace();
        }
        return null;
    }
    Method resultSetMethodResolver(Class<?> fieldType) throws NoSuchMethodException {
        if (String.class.equals(fieldType)) {
            return CustomResultSet.class.getMethod("getString", int.class);
        } else if (int.class.equals(fieldType)) {
            return CustomResultSet.class.getMethod("getInt", int.class);
        } else if (Instant.class.equals(fieldType)){
            return CustomResultSet.class.getMethod("getDateTime", int.class);
        } else if ( long.class.equals(fieldType)){
            return CustomResultSet.class.getMethod("getLong", int.class);
        }
        return CustomResultSet.class.getMethod("getString",int.class);
    }
}
