using RPGHeroes.Enums;
using RPGHeroes.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGHeroes.Classes
{
    public class Warrior : IClass
    {
        public ClassType ClassType => ClassType.Warrior;
        public HeroAttribute BaseStats => new(5, 2, 1);
        public HeroAttribute LevelUpStats => new(3, 2, 1);
        public WeaponType[] AllowedWeapons => new WeaponType[] { WeaponType.Axe, WeaponType.Sword, WeaponType.Hammer };
        public ArmorType[] AllowedArmor => new ArmorType[] { ArmorType.Mail, ArmorType.Plate };

        public HeroAttribute LevelUp()
        {
            return LevelUpStats;
        }
    }
}
