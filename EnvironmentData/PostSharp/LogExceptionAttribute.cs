namespace EnvironmentData.PostSharp
{
    using System;
    using System.Reflection;
    using log4net;
    using global::PostSharp.Aspects;
    using global::PostSharp.Extensibility;

    /// <summary>
    /// This attribute will log exceptions.
    /// </summary>
    [Serializable]
    [LinesOfCodeAvoided(75)]
    [MulticastAttributeUsage(PersistMetaData = true)]
    public sealed class LogExceptionAttribute : OnExceptionAspect
    {
        private readonly bool _shouldFlushLogger;

        private Type _type;

        [NonSerialized]
        private ILog _logger;

        public LogExceptionAttribute()
        {
        }

        public LogExceptionAttribute(bool shouldFlushLogger = false) : this()
        {
            this._shouldFlushLogger = shouldFlushLogger;
        }

        public override void CompileTimeInitialize(MethodBase method, AspectInfo aspectInfo)
        {
            base.CompileTimeInitialize(method, aspectInfo);

            this._type = method.DeclaringType;
        }

        public override void OnException(MethodExecutionArgs args)
        {
            PostsharpExceptionHandler.Handle(this._shouldFlushLogger, this.GetLogger(), args);
        }

        #region private methods
        private ILog GetLogger()
        {
            var assemblyName = this._type.Assembly.GetName();
            return this._logger ?? (this._logger = LogManager.GetLogger(assemblyName.Name + " " + assemblyName.Version));
        }
        #endregion 
    }
}
