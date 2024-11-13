using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Altx.PortScanner.Web.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly IScanTaskAppService _appService;

    public List<ScanTaskDto> ScanTasks { get; private set; }

    public IndexModel(ILogger<IndexModel> logger,
        IScanTaskAppService appService)
    {
        _logger = logger;
        _appService = appService;

        ScanTasks = new List<ScanTaskDto>();
    }

    public async Task OnGet()
    {
        ScanTasks = await _appService.GetListAsync(new ScanTaskListRequest());
    }

    public async Task OnPost(CreateScanTaskDto input)
    {
        if (!ModelState.IsValid)
            return;

        await _appService.CreateAsync(input);

        await OnGet();
    }
}
