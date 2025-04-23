using CombatPad.Models;
using CombatPad.Services.Interface;
using System.IO;
using System.Text.Json;

namespace CombatPad.Services
{
    public class FileSettingsService : ISettingsService
    {
        public Config GetConfig()
        {
            var folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            var path = Path.Combine(folder, "CombatPad");
            _ = Directory.CreateDirectory(path);

            var filePath = Path.Combine(path, "config.json");

            if (File.Exists(filePath))
            {
                var json = File.ReadAllText(filePath);
                return JsonSerializer.Deserialize<Config>(json)!;
            }

            return new();
        }

        public void SaveConfig(Config config)
        {
            var folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            var path = Path.Combine(folder, "CombatPad");
            _ = Directory.CreateDirectory(path);
            var filePath = Path.Combine(path, "config.json");
            var json = JsonSerializer.Serialize(config);

            File.WriteAllText(filePath, json);
        }
    }
}
