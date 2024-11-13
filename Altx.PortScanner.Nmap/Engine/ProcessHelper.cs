using System.Diagnostics;

namespace Altx.PortScanner.Nmap.Engine;

public static class ProcessHelper
{
    public static void AddArgument(this ProcessStartInfo startInfo, string arg)
    {
        startInfo.ArgumentList.Add(arg);
    }

    public static void AddManyArguments(this ProcessStartInfo startInfo, IEnumerable<string> args)
    {
        foreach (string arg in args)
            startInfo.ArgumentList.Add(arg);
    }
}