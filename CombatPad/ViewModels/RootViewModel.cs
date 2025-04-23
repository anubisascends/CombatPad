using CombatPad.Models;
using CombatPad.Repositories.Interfaces;
using CombatPad.Services.Interface;
using CombatPad.ViewModels.Interfaces;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MahApps.Metro.Controls.Dialogs;
using Microsoft.Win32;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows.Ink;
using System.Windows.Media;

namespace CombatPad.ViewModels
{
    public partial class RootViewModel(IRepository repository, IDialogCoordinator dialogCoordinator, ISettingsService settingsService) : ObservableObject, IViewModel
    {
        [ObservableProperty]
        private StrokeCollection _NoteStrokes = new();
        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(RemoveCombatItemCommand))]
        private ListItem? _SelectedCombatItem;
        [ObservableProperty]
        private string? _SaveFilePath;
        [ObservableProperty]
        private float _Zoom = 1;
        [ObservableProperty]
        private int _SelectedTrashItem = 0;

        public ObservableCollection<ListItem> Items { get; } = [];
        public ObservableCollection<MarkerItem> Markers { get; } = [];
        public IRepository Repository { get; } = repository;
        public IDialogCoordinator DialogCoordinator { get; } = dialogCoordinator;
        public ISettingsService SettingsService { get; } = settingsService;
        public Config Config { get; } = settingsService.GetConfig();

        private void CreateListItem<T>(string label) where T : ListItem, new()
        {
            if (!string.IsNullOrWhiteSpace(label))
            {
                var top = 0d;

                if (Items.Any())
                {
                    top = Items.Max(x => x.Top) + 35;
                }

                Items.Add(new T { Label = label, Top = top });
            }
        }

        [RelayCommand]
        private async Task AddPlayerCharacter()
        {
            var result = await DialogCoordinator.ShowInputAsync(this, "New Player", "Please enter the player's name");
            CreateListItem<PlayerCharacter>(result);
        }

        [RelayCommand]
        private async Task AddNonPlayerCharacter() 
        {
            var result = await DialogCoordinator.ShowInputAsync(this, "New NPC", "Please enter the NPC's name");
            CreateListItem<NonPlayerCharacter>(result);
        }

        [RelayCommand]
        private async Task AddHazard()
        {
            var result = await DialogCoordinator.ShowInputAsync(this, "New Hazard", "Please enter a label for this hazard.");
            CreateListItem<Hazard>(result);
        }

        [RelayCommand]
        private async Task AddCondition()
        {
            var result = await DialogCoordinator.ShowInputAsync(this, "New Condition", "Please enter a label for this condition");
            CreateListItem<Condition>(result);
        }

        [RelayCommand]
        private void AddMarker(string color)
        {
            var converter = new ColorConverter();
            var brush = (Color)converter.ConvertFromInvariantString(color);
            var counter = Markers.Where(x => x.Color == brush!).Count() + 1;

            Markers.Add(new() { Label = counter.ToString(), Color = brush });
        }

        [RelayCommand(CanExecute = nameof(CanRemoveCombatItem))]
        private async Task RemoveCombatItem()
        {
            IEnumerable<ListItem> items = SelectedTrashItem switch
            {
                1 => Items.Where(x => x is PlayerCharacter),
                2 => Items.Where(x => x is NonPlayerCharacter && x is not PlayerCharacter),
                3 => Items.Where(x => x is Hazard),
                4 => Items.ToList(),
                _ => [SelectedCombatItem!],
            };

            if (items.Any())
            {
                var result = await DialogCoordinator.ShowMessageAsync(this,
                    "Comfirm Delete",
                    $"Are you sure you want to delete {items.Count()} items?",
                    MessageDialogStyle.AffirmativeAndNegative);

                if (result == MessageDialogResult.Affirmative)
                {
                    foreach (var item in items.ToArray())
                    {
                        Items.Remove(item);
                        SelectedCombatItem = null;
                    }
                }
            }
        }
        private bool CanRemoveCombatItem() => Items.Any();

        [RelayCommand]
        private void Save()
        {
            if (string.IsNullOrWhiteSpace(SaveFilePath))
            {
                SaveAs();
                return;
            }

            using var stream = new MemoryStream();
            NoteStrokes.Save(stream);

            var document = new DocumentDto(Items.Where(x => x is PlayerCharacter).ToArray().Cast<PlayerCharacter>(), 
                Items.Where(x => x is NonPlayerCharacter && x is not PlayerCharacter).ToArray().Cast<NonPlayerCharacter>(), 
                Items.Where(x => x is Hazard).ToArray().Cast<Hazard>(),
                Items.Where(x => x is Models.Condition).ToArray().Cast<Models.Condition>(), 
                Markers);
            Repository.Save(document, SaveFilePath);
        }

        [RelayCommand]
        private void SaveAs()
        {
            var dlg = new SaveFileDialog 
            {
                Filter = "Combat Pad Files|*.cbp",
                Title = "Please select a file to save to..."
            };

            if(dlg.ShowDialog() ?? false)
            {
                SaveFilePath = dlg.FileName;
                Save();
            }
        }

        [RelayCommand]
        private void Load()
        {
            var dlg = new OpenFileDialog
            {
                Title = "Please select a file to load...",
                Filter = "Combat Pad Files|*.cbp"
            };

            if(dlg.ShowDialog() ?? false)
            {
                Items.Clear();
                Markers.Clear();

                SaveFilePath = dlg.FileName;
                var document = Repository.Load(SaveFilePath);

                foreach (var item in Enumerable.Concat<ListItem>(document.PCs, document.NPCs).Concat(document.Hazards).Concat(document.Conditions)) 
                {
                    Items.Add(item);
                }

                foreach (var m in document.MarkerItems)
                {
                    Markers.Add(m);
                }
            }
        }

        [RelayCommand]
        private void Import()
        {
            var dlg = new OpenFileDialog
            {
                Title = "Please select a file to import...",
                Filter = "Combat Pad Files|*.cbp"
            };

            if(dlg.ShowDialog() ?? false)
            {
                var document = Repository.Load(dlg.FileName);

                foreach (var item in Enumerable.Concat<ListItem>(document.NPCs, document.Hazards))
                {
                    Items.Add(item);
                }

                foreach (var m in document.MarkerItems)
                {
                    Markers.Add(m);
                }
            }
        }

        [RelayCommand]
        private void New()
        {
            Markers.Clear();
            Items.Clear();
            NoteStrokes.Clear();
        }

        [RelayCommand]
        private void Settings()
        {

        }
    }
}
