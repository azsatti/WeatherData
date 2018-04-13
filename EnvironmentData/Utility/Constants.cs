namespace EnvironmentData.Utility
{
    using System.Globalization;

    public static class Constants
    {
        /// <summary>
        /// The UK culture.
        /// </summary>
        public static readonly CultureInfo UkCulture = new CultureInfo("en-GB");

        /// <summary>
        /// The UK date format.
        /// </summary>
        public static readonly string UkDateTimeFormat = "dd/MM/yy h:mm";

        /// <summary>
        /// The API Date format.
        /// </summary>
        public static readonly string ApiDateFormat = "yyyy-MM-dd";

        /// <summary>
        /// The API Node to read.
        /// </summary>
        public static readonly string NodeName = "items";
    }
}
