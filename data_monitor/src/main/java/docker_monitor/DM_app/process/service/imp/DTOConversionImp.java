package docker_monitor.DM_app.process.service.imp;

import docker_monitor.DM_app.process.database.entities.*;
import docker_monitor.DM_app.process.service.DTOConversion;
import docker_monitor.DM_app.web.dto.*;
import org.modelmapper.ModelMapper;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.List;

@Service
public class DTOConversionImp implements DTOConversion {
    @Autowired
    private ModelMapper modelMapper;

    public ContainerDTO convertToContainerDTO(Container container){
        return modelMapper.map(container,ContainerDTO.class);
    }
    public List<ContainerDTO> convertToContainerDTO(List<Container> containers){
        return containers.stream().map(object -> modelMapper.map(object,ContainerDTO.class)).toList();
    }

    public CpuDTO convertToCpuDTO(List<Cpu> values, Container container){
        CpuDTO result = new CpuDTO();
        result.setValues(values.stream().map(object -> modelMapper.map(object, CpuSampleDTO.class)).toList());
        result.setContainer(convertToContainerDTO(container));
        return result;
    }
    public IODTO convertToIODTO(List<IO> values, Container container){
        IODTO result = new IODTO();
        result.setValues(values.stream().map(object -> modelMapper.map(object, IOSampleDTO.class)).toList());
        result.setContainer(convertToContainerDTO(container));
        return result;
    }
    public MemoryDTO convertToMemDTO(List<Memory> values, Container container){
        MemoryDTO result = new MemoryDTO();
        result.setValues( values.stream().map(object -> modelMapper.map(object, MemorySampleDTO.class)).toList());
        result.setContainer(convertToContainerDTO(container));
        return result;
    }
    public NetDTO convertToNetDTO(List<Net> values, Container container){
        NetDTO result = new NetDTO();
        result.setValues(values.stream().map(object -> modelMapper.map(object, NetSampleDTO.class)).toList());
        result.setContainer(convertToContainerDTO(container));
        return result;
    }
}
