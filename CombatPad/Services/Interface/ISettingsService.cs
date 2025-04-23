using CombatPad.Models;

namespace CombatPad.Services.Interface
{
    public interface ISettingsService
    {
        public Config GetConfig();
        public void SaveConfig(Config config);
    }
}
