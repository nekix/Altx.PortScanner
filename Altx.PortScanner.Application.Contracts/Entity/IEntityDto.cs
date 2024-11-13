namespace Altx.PortScanner.Entity;

public interface IEntityDto<TKey>
{
    TKey Id { get; set; }
}