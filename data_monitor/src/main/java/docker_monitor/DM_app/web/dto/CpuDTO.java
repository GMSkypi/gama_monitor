package docker_monitor.DM_app.web.dto;

import java.util.List;

public class CpuDTO{
    private List<CpuSampleDTO> values;
    private ContainerDTO container;


    public List<CpuSampleDTO> getValues() {
        return values;
    }

    public void setValues(List<CpuSampleDTO> values) {
        this.values = values;
    }

    public ContainerDTO getContainer() {
        return container;
    }

    public void setContainer(ContainerDTO container) {
        this.container = container;
    }
}
