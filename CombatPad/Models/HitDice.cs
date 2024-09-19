using System.Collections.ObjectModel;
using System.Text;
using System.Text.Json.Serialization;

namespace CombatPad.Models
{
    public class HitDice : ObservableCollection<HitDie>
    {
        [JsonIgnore]
        public int Max => this.Sum(x => x.Sides);
        [JsonIgnore]
        public int Average => this.Sum(x => x.Average);
        [JsonIgnore]
        public int Rolled => this.Sum(x => x.Rolled);

        public int Roll() => this.Sum(x => x.Roll());

        protected override void InsertItem(int index, HitDie item)
        {
            item.Roll();
            base.InsertItem(index, item);
        }

        public override string ToString()
        {
            var builder = new StringBuilder();
            var groups = this.GroupBy(x => x.Sides).ToList();

            foreach (var group in groups) 
            {
                if(builder.Length > 0)
                {
                    builder.Append(", ");
                }

                builder.Append($"{group.Count()}d{group.Key}");
            }

            return builder.ToString();
        }
    }
}
