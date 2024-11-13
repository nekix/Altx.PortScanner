namespace Altx.PortScanner;

/// <summary>
/// Represents the status of a host port scan task.
/// </summary>
public enum ScanStatus
{
    /// <summary>
    /// The scan task is currently wait for run.
    /// </summary>
    Wait,

    /// <summary>
    /// The scan task is currently running.
    /// </summary>
    Run,

    /// <summary>
    /// The scan task has completed successfully.
    /// </summary>
    Completed,

    /// <summary>
    /// An error occurred during the scan task.
    /// </summary>
    Error
}