
    using global::MyFirstWebAPIProject.Models;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Options;
 

    namespace ASPNETcorewebAPI.Controllers
    {
        [Route("api/[controller]")]
        [ApiController]
        public class ConfigTestController1 : ControllerBase
        {
            private readonly MyAppSettingsOptions _settingsFromOptions;
            private readonly MyAppSettingsOptions _settingsFromSnapshot;
            private readonly IOptionsMonitor<MyAppSettingsOptions> _settingsMonitor;

            // Constructor injects all three types
            public ConfigTestController1(
                IOptions<MyAppSettingsOptions> options,
                IOptionsSnapshot<MyAppSettingsOptions> snapshot,
                IOptionsMonitor<MyAppSettingsOptions> monitor)
            {
                // IOptions<T> → Singleton-like, values fixed at app startup
                _settingsFromOptions = options.Value;

                // IOptionsSnapshot<T> → Scoped, refreshed per request (only in Web apps)
                _settingsFromSnapshot = snapshot.Value;

                // IOptionsMonitor<T> → Singleton, supports change notifications and real-time reload
                _settingsMonitor = monitor;
            }

            [HttpGet("compare")]
        public IActionResult CompareOptions()
        {

           
            return Ok(new
                {
                    // These three may return different values if config changes during runtime
                    FromIOptions = new
                    {
                        _settingsFromOptions.ApplicationName,
                        _settingsFromOptions.Version,
                        _settingsFromOptions.DefaultPageSize
                    },
                    FromIOptionsSnapshot = new
                    {
                        _settingsFromSnapshot.ApplicationName,
                        _settingsFromSnapshot.Version,
                        _settingsFromSnapshot.DefaultPageSize
                    },
                    FromIOptionsMonitor = new
                    {
                        _settingsMonitor.CurrentValue.ApplicationName,
                        _settingsMonitor.CurrentValue.Version,
                        _settingsMonitor.CurrentValue.DefaultPageSize
                    }
                });
            }
        }
    }


