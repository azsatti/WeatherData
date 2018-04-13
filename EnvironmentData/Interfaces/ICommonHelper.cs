namespace EnvironmentData.Interfaces
{
    using System.Collections.Generic;

    public interface ICommonHelper
    {
        IEnumerable<T> GetList<T>(string url);
    }
}
