package docker_monitor.DM_app.web.dto;

import java.time.Instant;

public class ContainerDTO {
    private String id;
    private String dockerID;
    private String name;
    private String image;
    private Instant lastRecord;

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

    public Instant getLastRecord() {
        return lastRecord;
    }

    public void setLastRecord(Instant lastRecord) {
        this.lastRecord = lastRecord;
    }
}
