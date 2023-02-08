using RPGHeroes.Enums;
using RPGHeroes.Heroes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGHeroes.Interfaces
{
    public interface IEquippable
    {
        string Name { get; }
        int RequiredLevel { get; }
        EquipmentSlot Slot { get; }
        bool Equip(Hero hero);
    }
}
