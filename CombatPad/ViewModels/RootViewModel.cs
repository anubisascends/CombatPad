using CombatPad.Models;
using CombatPad.Repositories.Interfaces;
using CombatPad.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Win32;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Ink;
using System.Windows.Media;

namespace CombatPad.ViewModels
{
    public partial class RootViewModel(IRepository repository) : ObservableObject, IViewModel
    {
        [ObservableProperty]
        private StrokeCollection _NoteStrokes = new();
        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(RemoveCombatItemCommand))]
        private object? _SelectedCombatItem;
        [ObservableProperty]
        private string? _SaveFilePath;

        public ObservableCollection<CombatItem> Items { get; } = [];
        public ObservableCollection<MarkerItem> Markers { get; } = [];
        public IRepository Repository { get; } = repository;

        [RelayCommand]
        private void AddPlayerCharacter() => Items.Add(new CombatItem { Label = "New PC", Type = CombatItemType.PlayerCharacter, Counter = Items.Count(x => x.Type == CombatItemType.PlayerCharacter) + 1 });

        [RelayCommand]
        private void AddNonPlayerCharacter() => Items.Add(new CombatItem { Label = "New NPC", Type = CombatItemType.NonPlayerCharacter, Counter = Items.Count(x => x.Type == CombatItemType.NonPlayerCharacter) + 1 });

        [RelayCommand]
        private void AddHazard() => Items.Add(new CombatItem { Label = "New Hazard", Type = CombatItemType.Hazard, Counter = Items.Count(x => x.Type == CombatItemType.Hazard) + 1 });

        [RelayCommand]
        private void AddCondition() => Items.Add(new CombatItem { Label = "New Condition", Type = CombatItemType.Condition });

        [RelayCommand]
        private void AddMarker(string color)
        {
            var converter = new ColorConverter();
            var brush = (Color)converter.ConvertFromInvariantString(color);
            var counter = Markers.Where(x => x.Color == brush!).Count() + 1;

            Markers.Add(new() { Label = counter.ToString(), Color = brush });
        }

        [RelayCommand(CanExecute = nameof(CanRemoveCombatItem))]
        private void RemoveCombatItem()
        {
            var view = App.Host.Services.GetRequiredService<RootView>();

            if (SelectedCombatItem is CombatItem combatItem)
            {
                var result = MessageBox.Show(view,
                    $"Are you sure you want remove {combatItem?.Label}?",
                    "Confirm Delete",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    Items.Remove(combatItem!);
                }
            }
            else if (SelectedCombatItem is MarkerItem markerItem) 
            {
                var result = MessageBox.Show(view,
                    $"Are you sure you want remove the selected marker?",
                    "Confirm Delete",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    Markers.Remove(markerItem);
                }
            }
        }
        private bool CanRemoveCombatItem() => SelectedCombatItem != null;

        [RelayCommand]
        private void Save()
        {
            if (string.IsNullOrWhiteSpace(SaveFilePath))
            {
                SaveAs();
                return;
            }

            var document = new DocumentDto(Items, Markers, NoteStrokes);
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

                foreach (var ci in document.CombatItems)
                {
                    Items.Add(ci);
                }

                foreach (var m in document.MarkerItems)
                {
                    Markers.Add(m);
                }

                NoteStrokes = document.Strokes ?? new();
            }
        }
    }
}
