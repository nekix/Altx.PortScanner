using AutoMapper;

namespace Altx.PortScanner;

public class ApplicationAutoMapperProfile : Profile
{
    public ApplicationAutoMapperProfile()
    {
        CreateMap<ScanTask, ScanTaskDto>()
            .ForMember(dest => dest.HostName, opt => opt.MapFrom(src => src.Host.HostName))
            .ForMember(dest => dest.OpenPortsCount, opt => opt.MapFrom<PortsCountResolver>())
            .ForMember(dest => dest.ScanStatus, opt => opt.MapFrom(src => (int)src.Status));
    }
}

public class PortsCountResolver : IValueResolver<ScanTask, ScanTaskDto, int?>
{
    public int? Resolve(ScanTask source, ScanTaskDto destination, int? destMember, ResolutionContext context)
    {
        return source.Result?.Ports.Count;
    }
}