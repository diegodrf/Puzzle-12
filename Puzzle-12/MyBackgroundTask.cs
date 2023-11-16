using System.Diagnostics;

namespace Puzzle_12;

/// <summary>
/// This is a background task that runs continuously in the background.
/// In Program.cs, we register this as a singleton service so that it
/// can be injected into other components and run as only one instance.
/// In Index.razor, we inject this service to start and stop the task.
/// The task starts automatically when the service is instantiated.
/// 
/// Is there a better way to implement a background task in a Blazor Server app?
/// 
/// </summary>
public class MyBackgroundTask : IHostedService, IDisposable
{
    private Timer? _timer;

    public MyBackgroundTask()
    {
        
    }

    private void ProcessDataAsync(object? state)
    {
        // Processing logic goes here.
        Debug.WriteLine($"Processing Data at {DateTime.Now.ToLongTimeString()}");
    }

    private void LogError(Exception ex)
    {
        // Log the error (implementation omitted for brevity)
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        _timer = new Timer(ProcessDataAsync, null, TimeSpan.Zero, TimeSpan.FromSeconds(5));
        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }

    public void Dispose()
    {
        _timer?.Dispose();
    }
}

