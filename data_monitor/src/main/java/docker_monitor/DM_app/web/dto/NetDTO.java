package docker_monitor.DM_app.web.dto;

import java.util.List;

public class NetDTO {
    private List<NetSampleDTO> values;
    private ContainerDTO container;

    public List<NetSampleDTO> getValues() {
        return values;
    }

    public void setValues(List<NetSampleDTO> values) {
        this.values = values;
    }

    public ContainerDTO getContainer() {
        return container;
    }

    public void setContainer(ContainerDTO container) {
        this.container = container;
    }
}
