using System.Collections.ObjectModel;

namespace CombatPad.Models.Interfaces
{
    public interface IConditionContainer
    {
        ObservableCollection<Condition> Conditions { get; }
    }
}
