package docker_monitor.DM_app.web.dto;

import java.util.List;

public class IODTO {
    private List<IOSampleDTO> values;
    private ContainerDTO container;

    public List<IOSampleDTO> getValues() {
        return values;
    }

    public void setValues(List<IOSampleDTO> values) {
        this.values = values;
    }

    public ContainerDTO getContainer() {
        return container;
    }

    public void setContainer(ContainerDTO container) {
        this.container = container;
    }
}
