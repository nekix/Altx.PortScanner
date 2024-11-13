using Altx.PortScanner.Entity;
using Altx.PortScanner.Exceptions;

namespace Altx.PortScanner;

public sealed class ScanTask : IEntity<Guid>
{
    public Guid Id { get; private set; }

    public DateTime CreationTime { get; private set; }

    public DateTime? StartTime { get; private set; }

    public DateTime? CompletionTime { get; private set; }

    public ScanStatus Status { get; private set; }

    public Host Host { get; private set; }

    public PortRange PortRange { get; private set; }

    public ScanOptions Options { get; private set; }

    public ScanResult? Result { get; private set; }

    #region ORM
    #pragma warning disable CS8618
    /// <summary>
    /// Only for ORM and serialization. Do not use!
    /// </summary>
    [Obsolete("Only for ORM and serialization. Do not use!")]

    private ScanTask()

    {
        // Only for ORM and serialization. Do not use!
    }
    #pragma warning restore CS8618
    #endregion

    /// <summary>
    /// Initializes a new instance of the <see cref="ScanTask"/> class.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <param name="creationTime">The creation time.</param>
    /// <param name="host">The host.</param>
    /// <param name="portRange">The port range.</param>
    /// <param name="options">The options.</param>
    internal ScanTask(Guid id,
        DateTime creationTime,
        Host host,
        PortRange portRange,
        ScanOptions options)
    {
        Id = id;
        CreationTime = creationTime;

        Host = Check.NotNull(host, nameof(host));
        PortRange = Check.NotNull(portRange, nameof(portRange));
        Options = Check.NotNull(options, nameof(options));
    }

    /// <summary>
    /// Starts the task.
    /// Change status and start time.
    /// </summary>
    /// <param name="startTime">The start time.</param>
    /// <returns></returns>
    /// <exception cref="Main.ScanTaskAlreadyStartedException"></exception>
    /// <exception cref="Main.InvalidStartTimeException"></exception>
    internal ScanTask StartTask(DateTime startTime)
    {
        if (Status != ScanStatus.Wait)
            throw new ScanTaskAlreadyStartedException(Status);

        if (CreationTime < startTime)
            throw new InvalidStartTimeException(startTime, CreationTime);

        StartTime = startTime;
        Status = ScanStatus.Run;

        return this;
    }

    /// <summary>
    /// Completes the task.
    /// Change status and start time.
    /// </summary>
    /// <param name="сompletionTime">The сompletion time.</param>
    /// <param name="result">The result.</param>
    /// <returns></returns>
    /// <exception cref="Main.ScanTaskNotStartedException"></exception>
    internal ScanTask CompleteTask(DateTime сompletionTime, ScanResult result)
    {
        if (Status != ScanStatus.Run)
            throw new ScanTaskNotStartedException();

        //TODO: Validate сompletionTime and startTime

        //TODO: Validate port ranges and result ports

        //TODO: Validate result.ScanTaskId

        Result = Check.NotNull(result, nameof(result));
        Status = ScanStatus.Completed;
        CompletionTime = сompletionTime;

        return this;
    }


    /// <summary>
    /// Completes the task.
    /// Change status and start time.
    /// </summary>
    /// <param name="сompletionTime">The сompletion time.</param>
    /// <returns></returns>
    /// <exception cref="Main.ScanTaskNotStartedException"></exception>
    internal ScanTask CompleteTaskWithError(DateTime сompletionTime)
    {
        if (Status != ScanStatus.Run)
            throw new ScanTaskNotStartedException();

        //TODO: Validate сompletionTime and startTime

        Result = Check.NotNull(Result, nameof(Result));
        Status = ScanStatus.Error;
        CompletionTime = сompletionTime;

        return this;
    }
}
