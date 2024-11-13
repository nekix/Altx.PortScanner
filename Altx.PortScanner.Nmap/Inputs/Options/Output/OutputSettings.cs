namespace Altx.PortScanner.Nmap.Input.Options.Output;

public sealed class OutputSettings : IArguments
{
    #region Static mapper
    // TODO: Maybe move to inner static class or separate.

    private static readonly IReadOnlyList<KeyValuePair<OutputFormat, string>> OutputFormatsMap;

    static OutputSettings()
    {
        OutputFormatsMap = new List<KeyValuePair<OutputFormat, string>>
        {
            //new(OutputFormat.Normal, "-oN"),
            new(OutputFormat.Xml, "-oX")
        };
    }

    private static string MapOutputTargetToArgument(OutputTarget target)
    {
        string? format = OutputFormatsMap.FirstOrDefault(m => m.Key == target.Format).Value;
        if (format == null)
            throw new ArgumentException("Not existed output format!", nameof(target));

        return $"{format} {target.Path}";
    }
    #endregion

    private readonly List<OutputTarget> _outputTargets;
    public IReadOnlyList<OutputTarget> OutputTargets => _outputTargets;

    public OutputSettings()
    {
        _outputTargets = new List<OutputTarget>();
    }

    public OutputSettings AddTarget(OutputTarget target)
    {
        if (_outputTargets.Any(t => t.Format == target.Format))
            throw new ArgumentException($"Options also contains '{target.Format}' output target format!", nameof(target));

        _outputTargets.Add(target);

        return this;
    }

    public List<string> GetArguments()
    {
        return _outputTargets
            .ConvertAll(MapOutputTargetToArgument);
    }
}