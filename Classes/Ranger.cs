using RPGHeroes.Enums;
using RPGHeroes.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGHeroes.Classes
{
    public class Ranger : IClass
    {
        public ClassType ClassType => ClassType.Ranger;
        public HeroAttribute BaseStats => new(1, 7, 1);
        public HeroAttribute LevelUpStats => new(1, 5, 1);
        public WeaponType[] AllowedWeapons => new WeaponType[] { WeaponType.Bow };
        public ArmorType[] AllowedArmor => new ArmorType[] { ArmorType.Leather, ArmorType.Mail };

        public HeroAttribute LevelUp()
        {
            return LevelUpStats;
        }
    }
}
