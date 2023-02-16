using RPGHeroes.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGHeroes.Structs
{
    public struct HeroAttribute : IAttribute
    {
        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Intelligence { get; set; }

        public HeroAttribute(HeroAttribute other)
        {
            Strength = other.Strength;
            Dexterity = other.Dexterity;
            Intelligence = other.Intelligence;
        }
        public HeroAttribute(int strength, int dexterity, int intelligence)
        {
            this.Strength = strength;
            this.Dexterity = dexterity;
            this.Intelligence = intelligence;
        }
        /// <summary>
        /// Adds together the stats of this instance and another heroattribute
        /// </summary>
        /// <param name="other">Other HeroAttribute Instance</param>
        /// <returns>New HeroAttribute with values combined</returns>
        public HeroAttribute Increase(HeroAttribute other)
        {
            return new HeroAttribute(Strength + other.Strength, Dexterity + other.Dexterity, Intelligence + other.Intelligence);
        }
        /// <summary>
        /// Adds together stats of this HeroAttribute and int values
        /// </summary>
        /// <param name="Strength"></param>
        /// <param name="Dexterity"></param>
        /// <param name="Intelligence"></param>
        /// <returns>New HeroAttribute with values combined</returns>
        public HeroAttribute Increase(int Strength, int Dexterity, int Intelligence)
        {
            return new HeroAttribute(this.Strength + Strength, this.Dexterity + Dexterity, this.Intelligence + Intelligence);
        }

        public static HeroAttribute operator +(HeroAttribute a, HeroAttribute b)
        {
            return new HeroAttribute(a.Strength + b.Strength, a.Dexterity + b.Dexterity, a.Intelligence + b.Intelligence);
        }

        public override string ToString()
        {
            return $"Strength: {Strength}\nDexterity: {Dexterity}\nIntelligence: {Intelligence}";
        }

        public static bool operator ==(HeroAttribute a, HeroAttribute b)
        {
            if(a.Strength == b.Strength && a.Dexterity == b.Dexterity && a.Intelligence == b.Intelligence)
                return true;
            return false;
        }

        public static bool operator !=(HeroAttribute a, HeroAttribute b)
        {
            return !(a == b);
        }

    }
}
