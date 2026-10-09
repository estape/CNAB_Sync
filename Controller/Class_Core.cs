using System.IO;
using System.Text.Json;
using ConfigModel;

namespace Core
{
    public class Class_Core
    {
        private readonly string _configFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "CNAB_Sync", "config.json");

        /// <summary>
        /// Global configuration instance loaded into memory.
        /// </summary>
        public Class_Config AppConfig { get; private set; }

        public Class_Core()
        {
            // Load the config into the global variable on startup
            if (File.Exists(_configFilePath))
                AppConfig = ReadConfig();
            else
            {
                AppConfig = new Class_Config();
                WriteConfig(AppConfig);
            }
        }

        /// <summary>
        /// Writes the configuration to a JSON file
        /// </summary>
        /// <param name="config">The configuration to write</param>
        public void WriteConfig(Class_Config config)
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string jsonString = JsonSerializer.Serialize(config, options);
            
            var directory = Path.GetDirectoryName(_configFilePath);
            if (!string.IsNullOrEmpty(directory) && !Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            File.WriteAllText(_configFilePath, jsonString);
        }

        /// <summary>
        /// Reads the configuration from a JSON file
        /// </summary>
        /// <returns>The configuration</returns>
        public Class_Config ReadConfig()
        {
            if (File.Exists(_configFilePath))
            {
                string jsonString = File.ReadAllText(_configFilePath);
                return JsonSerializer.Deserialize<Class_Config>(jsonString) ?? new Class_Config();
            }
            
            return new Class_Config();
        }

        /// <summary>
        /// Cycles the theme based on the current theme
        /// </summary>
        /// <param name="theme">The current theme</param>
        /// <returns>The next theme</returns>
        public string CycleTheme(int theme)
        {
            AppConfig.ThemeDefault = theme;
            WriteConfig(AppConfig);

            return theme == 0 ? "SWITCH_THEME_LIGHT" : "SWITCH_THEME_DARK";
        }
    }
}