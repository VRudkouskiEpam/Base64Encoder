namespace WebViews.Models
{
    /// <summary>
    /// Defines the options for application seetings.
    /// </summary>
    public record class ApplicationSettings
    {
        /// <summary>
        /// Defines a name of the configuration section.
        /// </summary>
        public const string SectionName = "ApplicationSettings";

        /// <summary>
        /// Defines API base URL.
        /// </summary>
        public string? ApiBaseUrl { get; set; }
    }
}
