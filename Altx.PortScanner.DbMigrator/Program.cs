using Altx.PortScanner.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Altx.PortScanner.DbMigrator;

internal class Program
{
    static async Task Main(string[] _)
    {
        Console.WriteLine("Start init...");
        var factory = new ScanTaskDbContextFactory();
        var dbContext = factory.CreateDbContext(Array.Empty<string>());
        Console.WriteLine("Init completed!");

        Console.WriteLine("Start migration...");
        await dbContext.Database.MigrateAsync();
        Console.WriteLine("Migration completed! ");

        Console.WriteLine("All completed!");
    }
}
