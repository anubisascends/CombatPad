using CombatPad.Classes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombatPad.Models.Interfaces
{
    public interface ISkillContainer : IAbilityScoreContainer
    {
        ParentedObservableCollection<ISkillContainer, Skill> Skills { get; }
    }
}
