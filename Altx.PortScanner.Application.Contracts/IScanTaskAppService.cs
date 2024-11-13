namespace Altx.PortScanner;

public interface IScanTaskAppService
{
    Task<ScanTaskDto> GetAsync(Guid id);

    Task<List<ScanTaskDto>> GetListAsync(ScanTaskListRequest dto);

    Task<DetailedScanTaskDto> GetDetailsAsync(Guid id);

    Task<ScanTaskDto> CreateAsync(CreateScanTaskDto input);
}
