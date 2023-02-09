using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGHeroes.Structs
{
    public struct HeroAttribute
    {
        public int strength;
        public int dexterity;
        public int intelligence;

        public HeroAttribute(HeroAttribute other)
        {
            strength = other.strength;
            dexterity = other.dexterity;
            intelligence = other.intelligence;
        }
        public HeroAttribute(int strength, int dexterity, int intelligence)
        {
            this.strength = strength;
            this.dexterity = dexterity;
            this.intelligence = intelligence;
        }
        /// <summary>
        /// Adds together the stats of this instance and another heroattribute
        /// </summary>
        /// <param name="other">Other HeroAttribute Instance</param>
        /// <returns>New HeroAttribute with values combined</returns>
        public HeroAttribute Increase(HeroAttribute other)
        {
            return new HeroAttribute(strength + other.strength, dexterity + other.dexterity, intelligence + other.intelligence);
        }
        /// <summary>
        /// Adds together stats of this HeroAttribute and int values
        /// </summary>
        /// <param name="strength"></param>
        /// <param name="dexterity"></param>
        /// <param name="intelligence"></param>
        /// <returns>New HeroAttribute with values combined</returns>
        public HeroAttribute Increase(int strength, int dexterity, int intelligence)
        {
            return new HeroAttribute(this.strength + strength, this.dexterity + dexterity, this.intelligence + intelligence);
        }

        public static HeroAttribute operator +(HeroAttribute a, HeroAttribute b)
        {
            return new HeroAttribute(a.strength + b.strength, a.dexterity + b.dexterity, a.intelligence + b.intelligence);
        }

        public override string ToString()
        {
            return $"Strength: {strength}\nDexterity: {dexterity}\nIntelligence: {intelligence}";
        }

        public static bool operator ==(HeroAttribute a, HeroAttribute b)
        {
            if(a.strength == b.strength && a.dexterity == b.dexterity && a.intelligence == b.intelligence)
                return true;
            return false;
        }

        public static bool operator !=(HeroAttribute a, HeroAttribute b)
        {
            return !(a == b);
        }
    }
}
