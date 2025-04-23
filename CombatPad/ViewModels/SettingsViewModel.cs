using CombatPad.Models;
using CombatPad.Services.Interface;

namespace CombatPad.ViewModels
{
    public class SettingsViewModel
    {
        public SettingsViewModel(ISettingsService settingsService)
        {
            SettingsService = settingsService;
            Config = SettingsService.GetConfig();
        }

        public ISettingsService SettingsService { get; }
        public Config Config { get; }
    }
}
