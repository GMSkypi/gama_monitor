package docker_monitor.DM_app.web.dto;

import java.util.List;

public class MemoryDTO {
    private List<MemorySampleDTO> values;
    private ContainerDTO container;

    public List<MemorySampleDTO> getValues() {
        return values;
    }

    public void setValues(List<MemorySampleDTO> values) {
        this.values = values;
    }

    public ContainerDTO getContainer() {
        return container;
    }

    public void setContainer(ContainerDTO container) {
        this.container = container;
    }
}
