namespace EnvironmentData.Interfaces
{
    public interface IApiCallingUtil
    {
        /// <summary>
        /// Get and process data using JSON.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <param name="retryOverride">The retry override.</param>
        /// <returns>The response string.</returns>
        string GetAndProcessApiData(string url, int? retryOverride = null);
    }
}
