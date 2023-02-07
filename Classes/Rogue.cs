using RPGHeroes.Enums;
using RPGHeroes.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGHeroes.Classes
{
    public class Rogue : IClass
    {
        public ClassType ClassType => ClassType.Rogue;
        public HeroAttribute BaseStats => new(2, 6, 1);
        public HeroAttribute LevelUpStats => new(1, 4, 1);
        public WeaponType[] AllowedWeapons => new WeaponType[] { WeaponType.Dagger, WeaponType.Sword };
        public ArmorType[] AllowedArmor => new ArmorType[] { ArmorType.Leather, ArmorType.Mail };

        public HeroAttribute LevelUp()
        {
            return LevelUpStats;
        }
    }
}
