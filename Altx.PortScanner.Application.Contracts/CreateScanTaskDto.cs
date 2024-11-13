using System.ComponentModel.DataAnnotations;

namespace Altx.PortScanner
{
    public class CreateScanTaskDto
    {
        [Required]
        public string HostName { get; set; } = null!;

        [Required]
        [Range(0, DomainConsts.PortMaxNumber)]
        public int StartPort { get; set; }

        [Required]
        [Range(0, DomainConsts.PortMaxNumber)]
        public int EndPort { get; set; }

        [Required]
        public List<PortScanTypeDto> PortScanTypes { get; set; } = null!;
    }
}