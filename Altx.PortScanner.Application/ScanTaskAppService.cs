using Altx.PortScanner.Repositories;
using Altx.PortScanner.Services;
using AutoMapper;

namespace Altx.PortScanner;

public class ScanTaskAppService : IScanTaskAppService
{
    private readonly IScanTaskRepository _repository;
    private readonly IMapper _mapper;
    private readonly ScanTaskDomainService _domainService;

    public ScanTaskAppService(
        IScanTaskRepository repository,
        IMapper mapper,
        ScanTaskDomainService domainService)
    {
        _repository = Check.NotNull(repository, nameof(repository));
        _mapper = Check.NotNull(mapper, nameof(mapper));
        _domainService = Check.NotNull(domainService, nameof(domainService));
    }

    public async Task<ScanTaskDto> CreateAsync(CreateScanTaskDto input)
    {
        Check.NotNull(input, nameof(input));

        var host = new Host(input.HostName);
        var portRange = new PortRange(input.StartPort, input.EndPort);

        var portScanTypes = _mapper.Map <List<PortScanTypeDto>, List<PortScanType>>(input.PortScanTypes);

        var scanOptions = new ScanOptions(portScanTypes);

        var scanTask = _domainService.CreateScanTask(host, portRange, scanOptions);

        scanTask = await _repository.UpdateAsync(scanTask);

        return MapToOutputDto(scanTask);
    }

    public async Task<ScanTaskDto> GetAsync(Guid id)
    {
        // TODO: Optimize call
        var scanTask = await _repository.GetAsync(id);

        return MapToOutputDto(scanTask);
    }

    public async Task<DetailedScanTaskDto> GetDetailsAsync(Guid id)
    {
        var scanTask = await _repository.GetAsync(id);

        return MapToDetailedOutputDto(scanTask);
    }

    public async Task<List<ScanTaskDto>> GetListAsync(ScanTaskListRequest dto)
    {
        var scanTasks = await _repository.GetListAsync();

        return MapToListOutputDto(scanTasks);
    }

    private DetailedScanTaskDto MapToDetailedOutputDto(ScanTask scanTask)
    {
        return _mapper.Map<ScanTask, DetailedScanTaskDto>(scanTask);
    }

    private ScanTaskDto MapToOutputDto(ScanTask scanTask)
    {
        return _mapper.Map<ScanTask, ScanTaskDto>(scanTask);
    }

    private List<ScanTaskDto> MapToListOutputDto(List<ScanTask> scanTask)
    {
        return _mapper.Map<List<ScanTask>, List<ScanTaskDto>>(scanTask);
    }
}
