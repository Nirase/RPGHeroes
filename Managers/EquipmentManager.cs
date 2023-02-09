using RPGHeroes.Enums;
using RPGHeroes.Heroes;
using RPGHeroes.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGHeroes.Managers
{
    public static class EquipmentManager
    {
        private static Dictionary<Hero, Dictionary<EquipmentSlot, IEquippable?>> _heroEquipmentDict = new();
        private static Dictionary<Hero, WeaponType[]> _allowedWeapons = new();
        private static Dictionary<Hero, ArmorType[]> _allowedArmor = new();

        public static void Equip(Hero hero, IEquippable equippable)
        {
            if (_heroEquipmentDict[hero] == null)
            {
                _heroEquipmentDict[hero] = new Dictionary<EquipmentSlot, IEquippable?>
                {
                    [EquipmentSlot.Weapon] = null,
                    [EquipmentSlot.Head] = null,
                    [EquipmentSlot.Body] = null,
                    [EquipmentSlot.Legs] = null
                };
            }
            if (equippable.Equip(hero))
                _heroEquipmentDict[hero][equippable.Slot] = equippable;
        }

        public static void SetAllowedWeapons(Hero hero, WeaponType[] weapons)
        {
            _allowedWeapons[hero] = weapons;
        }

        public static void SetAllowedArmor(Hero hero, ArmorType[] armor)
        {
            _allowedArmor[hero] = armor;
        }

        public static void AddHero(Hero hero)
        {
            _heroEquipmentDict[hero] = new Dictionary<EquipmentSlot, IEquippable?>
            {
                [EquipmentSlot.Weapon] = null,
                [EquipmentSlot.Head] = null,
                [EquipmentSlot.Body] = null,
                [EquipmentSlot.Legs] = null
            };
            _allowedArmor[hero] = Array.Empty<ArmorType>();
            _allowedWeapons[hero] = Array.Empty<WeaponType>();
        }

        public static void RemoveHero(Hero hero)
        {
            _heroEquipmentDict.Remove(hero);
            _allowedArmor.Remove(hero);
            _allowedWeapons.Remove(hero);
        }

        public static IEquippable? GetEquippable(Hero hero, EquipmentSlot slot)
        {
            if (_heroEquipmentDict[hero] == null)
                return null;
            return _heroEquipmentDict[hero][slot];
        }

        public static Dictionary<EquipmentSlot, IEquippable?> GetAllEquipment(Hero hero)
        {
            return _heroEquipmentDict[hero];
        }

        public static WeaponType[] GetAllowedWeaponTypes(Hero hero)
        {
            return _allowedWeapons[hero];
        }
        public static ArmorType[] GetAllowedArmorTypes(Hero hero)
        {
            return _allowedArmor[hero];
        }
    }
}
