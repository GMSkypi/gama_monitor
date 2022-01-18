package docker_monitor.DM_app.process.service;

import docker_monitor.DM_app.process.database.entities.*;
import docker_monitor.DM_app.web.dto.*;

import java.util.List;

public interface DTOConversion {
    ContainerDTO convertToContainerDTO(Container container);
    List<ContainerDTO> convertToContainerDTO(List<Container> containers);
    CpuDTO convertToCpuDTO(List<Cpu> values, Container container);
    IODTO convertToIODTO(List<IO> values, Container container);
    MemoryDTO convertToMemDTO(List<Memory> values, Container container);
    NetDTO convertToNetDTO(List<Net> values, Container container);
}
