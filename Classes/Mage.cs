using RPGHeroes.Enums;
using RPGHeroes.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGHeroes.Classes
{
    public class Mage : IClass
    {
        public ClassType ClassType => ClassType.Mage;
        public HeroAttribute BaseStats => new(1, 1, 8);
        public HeroAttribute LevelUpStats => new(1, 1, 5);
        public WeaponType[] AllowedWeapons => new WeaponType[] { WeaponType.Staff, WeaponType.Wand };
        public ArmorType[] AllowedArmor => new ArmorType[] { ArmorType.Cloth };

        public HeroAttribute LevelUp()
        {
            return LevelUpStats;
        }
    }
}
