namespace EnvironmentData.PostSharp
{
    using System;
    using System.Linq;
    using System.Threading;
    using log4net;
    using log4net.Appender;
    using global::PostSharp.Aspects;
    using Properties;

    public static class PostsharpExceptionHandler
    {
        public static void Handle(bool shouldFlushLogger, ILog logger, MethodExecutionArgs args)
        {
            var exception = args.Exception;
            if (exception is OperationCanceledException)
            {
                // don't want to log cancellation exceptions.
                if (shouldFlushLogger)
                {
                    // flush the loggers.
                    var appenders = LogManager.GetRepository().GetAppenders();
                    foreach (var bufferedAppender in appenders.OfType<BufferingAppenderSkeleton>())
                    {
                        bufferedAppender.Flush();
                    }

                    Thread.Sleep(250);
                }

                return;
            }

            logger.Error(exception);

            if (exception.InnerException != null)
            {
                logger.Error(Settings.Default.InnerException, exception.InnerException);
            }

            if (shouldFlushLogger)
            {
                // flush the loggers.
                var appenders = LogManager.GetRepository().GetAppenders();
                foreach (var bufferedAppender in appenders.OfType<BufferingAppenderSkeleton>())
                {
                    bufferedAppender.Flush();
                }

                Thread.Sleep(250);
            }
        }
    }
}
