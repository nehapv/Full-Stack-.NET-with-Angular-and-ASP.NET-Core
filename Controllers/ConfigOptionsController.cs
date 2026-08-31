using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MyFirstWebAPIProject.Models;

namespace ASPNETcorewebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfigOptionsController : ControllerBase
    {
        // Strongly typed settings class injected via the Options Pattern
        private readonly MyAppSettingsOptions _settings;

        // The constructor receives IOptions<MyAppSettingsOptions> from DI
        // 'options.Value' gives us the bound configuration values
        public ConfigOptionsController(IOptions<MyAppSettingsOptions> options)
        {
            // Store the configuration values for use in actions
            _settings = options.Value;
        }

        // GET: api/configtest
        [HttpGet]
        public IActionResult GetConfigValues()
        {
            // Returning configuration values as JSON response
            // These values are coming from appsettings.json (or environment-specific overrides)
            return Ok(new
            {
                ApplicationName = _settings.ApplicationName,  // e.g. "MyFirstWebAPIProject"
                Version = _settings.Version,                  // e.g. "1.0.0"
                DefaultPageSize = _settings.DefaultPageSize   // e.g. 20
            });
        }

    }
}
