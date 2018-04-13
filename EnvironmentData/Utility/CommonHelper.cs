﻿namespace EnvironmentData.Utility
{
    using System.Collections.Generic;
    using System.Linq;
    using Interfaces;
    using Newtonsoft.Json.Linq;

    /// <summary>
    /// Common helper class to process the data and return typed object.
    /// </summary>
    public class CommonHelper : ICommonHelper
    {
        private static readonly ApiCallingUtil ApiCallingUtil;

        /// <summary>
        /// Initialises static members of the <see cref="CommonHelper"/> class.
        /// </summary>
        static CommonHelper()
        {
            ApiCallingUtil = new ApiCallingUtil();
        }

        public IEnumerable<T> GetList<T>(string url)
        {
            var data = ApiCallingUtil.GetAndProcessApiData(url);
            var searchResult = JObject.Parse(data);
            var results = searchResult[Constants.NodeName].Children().ToList();
            var resultList = results.Select(result => result.ToObject<T>()).ToList();
            return resultList;
        }
    }
}
