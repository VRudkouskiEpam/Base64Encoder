using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using WebViews.Models;

namespace WebViews.Controllers
{
    /// <summary>
    /// Represents application configuration related actions.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class ConfigurationController : ControllerBase
    {
        private readonly ApplicationSettings _settings;

        /// <summary>
        /// Constructs <see cref="ConfigurationController"/> instance.
        /// </summary>
        /// <param name="settings">An instance of <see cref="IOptions{ApplicationSettings}"/> object.</param>
        public ConfigurationController(IOptions<ApplicationSettings> settings)
        {
            _settings = settings.Value;
        }

        /// <summary>
        /// Gets application settings.
        /// </summary>
        /// <returns>
        /// The objects that represents application settings.
        /// </returns>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(
                new
                {
                    _settings.ApiBaseUrl
                });
        }
    }
}