using RPGHeroes.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGHeroes.Enums
{
    internal class Armor : IEquippable
    {
        private string _name;
        public string Name
        {
            get => _name;
            private set => _name = value;
        }
        private int _requiredValue;
        public int RequiredLevel
        {
            get => _requiredValue;
            private set => _requiredValue = value;
        }
        private EquipmentSlot _equipmentSlot;
        public EquipmentSlot Slot
        {
            get => _equipmentSlot;
            private set => _equipmentSlot = value;
        }
        public HeroAttribute ArmorAttribute { get; private set; }
        public ArmorType ArmorType { get; private set; }

        public Armor(string name, int requiredLevel, HeroAttribute armorAttribute, EquipmentSlot equipmentSlot, ArmorType armorType)
        {
            _name = name;
            _requiredValue = requiredLevel;
            _equipmentSlot = equipmentSlot;
            ArmorAttribute = armorAttribute;
            ArmorType = armorType;
        }

    }
}
