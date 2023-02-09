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
        HeroAttribute BaseStats { get; }
        HeroAttribute LevelUpStats { get; }
        public void LevelUp();

    }
}
