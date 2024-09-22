using CombatPad.Dialogs;
using CombatPad.Models;
using System.Windows;
using System.Windows.Controls;

namespace CombatPad.Components
{
    /// <summary>
    /// Interaction logic for NonPlayerCharacterPanel.xaml
    /// </summary>
    public partial class NonPlayerCharacterPanel : UserControl
    {
        public NonPlayerCharacterPanel()
        {
            InitializeComponent();
        }

        private void TextInput_DoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var dlg = new TextInputDialog();

            dlg.Title = "Please give a name";

            if(dlg.ShowDialog() ?? false)
            {
                var npc = DataContext as NonPlayerCharacter;

                npc.Label = dlg.Result;
            }
        }
    }
}
