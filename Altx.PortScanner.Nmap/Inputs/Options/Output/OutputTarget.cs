namespace Altx.PortScanner.Nmap.Input.Options.Output;

public sealed class OutputTarget
{
    private const string StdoutTargetPath = "-";

    public OutputFormat Format { get; private set; }

    public string Path { get; private set; }

    private OutputTarget(OutputFormat outputFormat, string outputFilename)
    {
        // TODO: Validate outputFormat enum.
        Format = outputFormat;

        Path = Check.NotNullOrWhiteSpace(outputFilename, nameof(outputFilename));
    }

    public static OutputTarget CreateFromStdout(OutputFormat outputFormat)
        => new OutputTarget(outputFormat, StdoutTargetPath);
}
