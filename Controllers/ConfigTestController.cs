using Microsoft.AspNetCore.Mvc;
using MyFirstWebAPIProject.Models;

namespace MyFirstWebAPIProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfigTestController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public ConfigTestController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public IActionResult GetConfigValues()
        {
            // Method 1: Direct access using keys
            var appName = _configuration["MyAppSettings:ApplicationName"];

            // Method 2: Access using GetSection
            var pageSize = _configuration.GetSection("MyAppSettings:DefaultPageSize").Value;

            // Method 3: Binding to a strongly-typed object
            // Here, the Key Names must be same as the Property Names
            var settings = new MyAppSettings();
            _configuration.GetSection("MyAppSettings").Bind(settings);

            return Ok(new
            {
                ApplicationName = appName,
                DefaultPageSize = pageSize,
                StronglyTyped = settings
            });
        }
    }
}

