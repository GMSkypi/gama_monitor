package docker_monitor.DM_app.process.database.entities;

import docker_monitor.DM_app.process.database.persistance.anotation.Column;
import docker_monitor.DM_app.process.database.persistance.anotation.Entity;
import docker_monitor.DM_app.process.database.persistance.anotation.Symbol;

@Entity(name = "Container")
public class Container {
    @Symbol
    @Column(name = "id")
    String id;

    @Column(name = "docekr_id")
    String dockerID;

    @Column(name = "names")
    String name;

    @Column(name = "image")
    String image;

    public String getId() {
        return id;
    }

    public void setId(String id) {
        this.id = id;
    }

    public String getDockerID() {
        return dockerID;
    }

    public void setDockerID(String dockerID) {
        this.dockerID = dockerID;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public String getImage() {
        return image;
    }

    public void setImage(String image) {
        this.image = image;
    }
}
