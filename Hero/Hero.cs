using RPGHeroes.Enums;
using RPGHeroes.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGHeroes.Hero
{
    public class Hero
    {
        private IClass _heroClass;
        public IClass HeroClass { get { return _heroClass; } }
        private HeroAttribute _stats;
        public int Level { get; private set; }

        Dictionary<EquipmentSlot, IEquippable> _equipmentSlots;

        public Hero(IClass heroClass)
        {
            _heroClass = heroClass;
            _stats = heroClass.BaseStats;
            Level = 1;
            _equipmentSlots = new();
        }

        public void LevelUp()
        {
            ++Level;
            _stats = _stats.Increase(_heroClass.LevelUpStats);
        }

        public void Equip(IEquippable equippable)
        {

            try
            {
                if (equippable.Equip(_heroClass))
                    _equipmentSlots[equippable.Slot] = equippable;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
