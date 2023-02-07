using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGHeroes.Interfaces
{
    public struct HeroAttribute
    {
        public int strength;
        public int dexterity;
        public int intelligence;

        public HeroAttribute(int strength, int dexterity, int intelligence)
        {
            this.strength = strength;
            this.dexterity = dexterity;
            this.intelligence = intelligence;
        }

        public HeroAttribute Increase(HeroAttribute other)
        {
            return new HeroAttribute(this.strength + other.strength, this.dexterity + other.dexterity, this.intelligence + other.intelligence);
        }

        public HeroAttribute Increase(int strength, int dexterity, int intelligence)
        {
            return new HeroAttribute(this.strength + strength, this.dexterity + dexterity, this.intelligence + intelligence);
        }
    }
}
