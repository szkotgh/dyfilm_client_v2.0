using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace dyfilm_client_v2._0.src
{
    public class ConfigManager
    {
        private static readonly string CONFIG_FILE_PATH = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "dyfilm", "config.ini");

        private static Dictionary<string, string> _settings = new Dictionary<string, string>();
        
        private static readonly Dictionary<string, string> _defaultValues = new Dictionary<string, string>
        {
            { "process_url", "https://film.dyhs.kr" },
            { "auth_token", "" },
            { "printer_type", "SELPHY_CP1300" }
        };

        /// <summary>
        /// Loads configuration file. Creates with default values if file doesn't exist.
        /// </summary>
        public static void LoadConfig()
        {
            _settings.Clear();
            
            // Initialize with default values
            foreach (var defaultSetting in _defaultValues)
            {
                _settings[defaultSetting.Key] = defaultSetting.Value;
            }
            
            // Load if configuration file exists
            if (File.Exists(CONFIG_FILE_PATH))
            {
                try
                {
                    string[] lines = File.ReadAllLines(CONFIG_FILE_PATH, Encoding.UTF8);
                    foreach (string line in lines)
                    {
                        if (string.IsNullOrWhiteSpace(line) || line.StartsWith("#"))
                            continue;
                            
                        int equalIndex = line.IndexOf('=');
                        if (equalIndex > 0)
                        {
                            string key = line.Substring(0, equalIndex).Trim();
                            string value = line.Substring(equalIndex + 1).Trim();
                            _settings[key] = value;
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Use default values if file reading fails
                    System.Diagnostics.Debug.WriteLine($"Failed to read configuration file: {ex.Message}");
                }
            }
            else
            {
                // Create with default values if file doesn't exist
                SaveConfig();
            }
        }

        /// <summary>
        /// Gets configuration value.
        /// </summary>
        /// <param name="key">Configuration key</param>
        /// <returns>Configuration value, empty string if not found</returns>
        public static string GetValue(string key)
        {
            return _settings.ContainsKey(key) ? _settings[key] : string.Empty;
        }

        /// <summary>
        /// Sets configuration value. (Only saved in memory, call SaveConfig() to save to file)
        /// </summary>
        /// <param name="key">Configuration key</param>
        /// <param name="value">Configuration value</param>
        public static void SetValue(string key, string value)
        {
            _settings[key] = value;
        }

        /// <summary>
        /// Saves current configuration to file.
        /// </summary>
        public static void SaveConfig()
        {
            if (!Directory.Exists(Path.GetDirectoryName(CONFIG_FILE_PATH)))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(CONFIG_FILE_PATH));
            }
            try
            {
                StringBuilder configContent = new StringBuilder();
                foreach (var setting in _settings)
                {
                    configContent.AppendLine($"{setting.Key}={setting.Value}");
                }
                
                File.WriteAllText(CONFIG_FILE_PATH, configContent.ToString(), Encoding.UTF8);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Failed to save configuration file: {ex.Message}");
                throw new Exception($"Failed to save configuration file: {ex.Message}");
            }
        }

        /// <summary>
        /// Returns configuration file path.
        /// </summary>
        public static string GetConfigFilePath()
        {
            return CONFIG_FILE_PATH;
        }

        /// <summary>
        /// Returns all configuration settings.
        /// </summary>
        public static Dictionary<string, string> GetAllSettings()
        {
            return new Dictionary<string, string>(_settings);
        }
    }
}
