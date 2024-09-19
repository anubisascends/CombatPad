using CombatPad.Classes.Interfaces;
using System.Collections.ObjectModel;

namespace CombatPad.Classes
{
    public class ParentedObservableCollection<TParent, TObject>(TParent parent) : ObservableCollection<TObject> where TObject : IParented<TParent>
    {
        public TParent Parent { get; init; } = parent;

        protected override void InsertItem(int index, TObject item)
        {
            base.InsertItem(index, item);
        }

        protected override void RemoveItem(int index)
        {
            var item = this[index];
            base.RemoveItem(index);
        }
    }
}
