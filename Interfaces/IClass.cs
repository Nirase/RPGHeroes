using RPGHeroes.Enums;
using RPGHeroes.Structs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGHeroes.Interfaces
{
    public interface IClass
    {
        ClassType ClassType { get; }
        HeroAttribute LevelUpStats { get; }
        WeaponType[] AllowedWeapons { get; }  
        ArmorType[] AllowedArmor { get; }
        public void LevelUp();

    }
}
