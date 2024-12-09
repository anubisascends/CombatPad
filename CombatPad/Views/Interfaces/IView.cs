using CombatPad.ViewModels.Interfaces;

namespace CombatPad.Views.Interfaces
{
    public interface IView<T> where T : IViewModel
    {
        T ViewModel { get; }
    }
}
