namespace MyFirstWebAPIProject.Models
{
    public class MyAppSettingsOptions
    {
        public string ApplicationName { get; set; } = string.Empty;
        public string Version { get; set; } = string.Empty;
        public int DefaultPageSize { get; set; }
    }
}
