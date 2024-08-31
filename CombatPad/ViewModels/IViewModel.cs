using System.ComponentModel;

namespace CombatPad.ViewModels
{
    public interface IViewModel : INotifyPropertyChanged, INotifyPropertyChanging
    {
    }

    public interface IView<T> where T : IViewModel
    {
        T ViewModel { get; }
    }
}
