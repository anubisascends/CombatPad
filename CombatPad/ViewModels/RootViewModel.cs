using CombatPad.Models;
using CombatPad.Repositories.Interfaces;
using CombatPad.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Win32;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Windows.Controls.Primitives;
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
        [ObservableProperty]
        private float _Zoom = 1;

        public ObservableCollection<ListItem> Items { get; } = [];
        public ObservableCollection<MarkerItem> Markers { get; } = [];
        public IRepository Repository { get; } = repository;

        [RelayCommand]
        private void AddPlayerCharacter() => Items.Add(new PlayerCharacter { Label = "New PC" });

        [RelayCommand]
        private void AddNonPlayerCharacter() => Items.Add(new NonPlayerCharacter { Label = "New NPC" });

        [RelayCommand]
        private void AddHazard() => Items.Add(new Hazard { Label = "New Hazard" });

        [RelayCommand]
        private void AddCondition() => Items.Add(new Models.Condition { Label = "New Condition" });

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

            if (SelectedCombatItem is ListItem listItem)
            {
                var result = MessageBox.Show(view,
                    $"Are you sure you want remove {listItem?.Label}?",
                    "Confirm Delete",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    Items.Remove(listItem!);
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

            using var stream = new MemoryStream();
            NoteStrokes.Save(stream);

            var document = new DocumentDto(Items.Where(x => x is PlayerCharacter).ToArray().Cast<PlayerCharacter>(), 
                Items.Where(x => x is NonPlayerCharacter && x is not PlayerCharacter).ToArray().Cast<NonPlayerCharacter>(), 
                Items.Where(x => x is Hazard).ToArray().Cast<Hazard>(),
                Items.Where(x => x is Models.Condition).ToArray().Cast<Models.Condition>(), 
                Markers, 
                stream.ToArray());
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

                if (document.Strokes.Count() > 0)
                {
                    using var stream = new MemoryStream(document.Strokes.ToArray());
                    NoteStrokes = new StrokeCollection(stream);
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

                using var stream = new MemoryStream(document.Strokes.ToArray());
                var strokes = new StrokeCollection(stream);

                NoteStrokes.Add(strokes);
            }
        }

        [RelayCommand]
        private void New()
        {
            Markers.Clear();
            Items.Clear();
            NoteStrokes.Clear();
        }
    }
}
