using RPGHeroes.Enums;
using RPGHeroes.Exceptions;
using RPGHeroes.Heroes;
using RPGHeroes.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGHeroes.Equipment
{
    public class Weapon : IEquippable
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
        public int WeaponDamage { get; private set; }
        public WeaponType WeaponType { get; private set; }

        public Weapon(string name, int requiredLevel, int weaponDamage, WeaponType weaponType)
        {
            _name = name;
            _requiredValue = requiredLevel;
            _equipmentSlot = EquipmentSlot.Weapon;
            WeaponDamage = weaponDamage;
            WeaponType = weaponType;
        }
        /// <summary>
        /// Checks if this can be equipped on a hero
        /// </summary>
        /// <param name="hero">Hero to equip weapon on</param>
        /// <returns>If weapon can be equipped</returns>
        /// <exception cref="InvalidArmorException">If the hero can't equip the weapon</exception>
        public bool Equip(Hero hero)
        {
            if (hero.AllowedWeapons.Contains(WeaponType) && hero.Level >= RequiredLevel)
                return true;
            throw new InvalidWeaponException("Can not equip this item");
        }
    }
}
