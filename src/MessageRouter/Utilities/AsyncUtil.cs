namespace MessageRouter.Utilities;

public static class AsyncUtil
{
    public static void RunSync(Func<Task> task) =>
        _taskFactory
            .StartNew(task)
            .Unwrap()
            .GetAwaiter()
            .GetResult();

    public static TResult RunSync<TResult>(Func<Task<TResult>> task) =>
        _taskFactory
            .StartNew(task)
            .Unwrap()
            .GetAwaiter()
            .GetResult();

    private static readonly TaskFactory _taskFactory = 
        new TaskFactory(CancellationToken.None,
            TaskCreationOptions.None,
            TaskContinuationOptions.None,
            TaskScheduler.Default);
        
}