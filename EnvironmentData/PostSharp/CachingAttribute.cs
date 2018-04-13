namespace EnvironmentData.PostSharp
{
    using System;
    using global::PostSharp.Aspects;

    /// <summary>
    /// We can implement mem-cache or <see cref="https://redis.io/"/> caching etc.
    /// </summary>
    [Serializable]
    public class CachingAttribute : MethodInterceptionAspect, IDisposable
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
