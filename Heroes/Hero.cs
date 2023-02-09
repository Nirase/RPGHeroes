using RPGHeroes.Enums;
using RPGHeroes.Equipment;
using RPGHeroes.Interfaces;
using RPGHeroes.Structs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGHeroes.Heroes
{
    public class Hero : IClass
    {
        public string Name { get; private set; }
        private HeroAttribute _stats;
        public HeroAttribute Stats { get { return _stats; } }
        public int Level { get; private set; }

        private ClassType _classType;
        public ClassType ClassType { get => _classType; }

        private HeroAttribute _baseStats;
        public HeroAttribute BaseStats { get => _baseStats; }
        
        private HeroAttribute _levelUpStats;
        public HeroAttribute LevelUpStats { get => _levelUpStats; }
        
        public WeaponType[] _allowedWeapons;
        public WeaponType[] AllowedWeapons { get => _allowedWeapons; }
        
        private ArmorType[] _allowedArmor;
        public ArmorType[] AllowedArmor { get => _allowedArmor; }
        public Dictionary<EquipmentSlot, IEquippable?> _equipmentSlots;

        public Hero(string name, ClassType classType)
        {
            _equipmentSlots = new();
            this.Name = name;
            this._classType = classType;
            this.Level = 1;
            _equipmentSlots[EquipmentSlot.Weapon] = null;
            _equipmentSlots[EquipmentSlot.Head] = null;
            _equipmentSlots[EquipmentSlot.Body] = null;
            _equipmentSlots[EquipmentSlot.Legs] = null;

            switch (classType) 
            {
                case ClassType.Mage:
                    _allowedWeapons = new WeaponType[] { WeaponType.Staff, WeaponType.Wand };
                    _allowedArmor = new ArmorType[] { ArmorType.Cloth };
                    _baseStats = new(1, 1, 8);
                    _stats = new(_baseStats);
                    _levelUpStats = new(1, 1, 5);
                    break;
                case ClassType.Warrior:
                    _allowedWeapons = new WeaponType[] { WeaponType.Axe, WeaponType.Sword, WeaponType.Hammer };
                    _allowedArmor = new ArmorType[] { ArmorType.Mail, ArmorType.Plate };
                    _baseStats = new(5, 2, 1);
                    _stats = new(_baseStats);
                    _levelUpStats = new(3, 2, 1);
                    break;
                case ClassType.Ranger:
                    _allowedWeapons = new WeaponType[] { WeaponType.Bow };
                    _allowedArmor = new ArmorType[] { ArmorType.Leather, ArmorType.Mail };
                    _baseStats = new(1, 7, 1);
                    _stats = new(_baseStats);
                    _levelUpStats = new(1, 5, 1);
                    break;
                case ClassType.Rogue:
                    _allowedWeapons = new WeaponType[] { WeaponType.Dagger, WeaponType.Sword };
                    _allowedArmor = new ArmorType[] { ArmorType.Leather, ArmorType.Mail };
                    _baseStats = new(2, 6, 1);
                    _stats = new(_baseStats);
                    _levelUpStats = new(1, 4, 1);
                    break;
                default:
                    _allowedArmor = new ArmorType[0];
                    _allowedWeapons = new WeaponType[0];
                    _baseStats = new(0, 0, 0);
                    _stats = new(_baseStats);
                    _levelUpStats = new(0, 0, 0);
                    break;
            }
        }


        public void Equip(IEquippable equippable)
        {

            if (equippable.Equip(this))
                _equipmentSlots[equippable.Slot] = equippable;
        }
        public HeroAttribute TotalAttributes()
        {
            var result = new HeroAttribute(_stats);
            foreach(var value in _equipmentSlots.Values)
            {
                var converted = (value as Armor);
                if (converted == null)
                    continue;
                result += converted.ArmorAttribute;
            }

            return result;
        }

        public void Display()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Name: {Name}");
            sb.AppendLine($"Class: {ClassType.GetName(ClassType)}");
            sb.AppendLine($"Level: {Level}");
            sb.AppendLine(_stats.ToString());
            sb.AppendLine($"Damage: {Damage().ToString()}");
            Console.WriteLine(sb);
        }

        public double Damage()
        {
            var baseDamage = 0d;
            var totalAttributes = TotalAttributes();
            switch(ClassType)
            {
                case ClassType.Mage:
                    baseDamage = totalAttributes.intelligence; 
                    break;
                case ClassType.Warrior:
                    baseDamage = totalAttributes.strength;
                    break;
                case ClassType.Ranger:
                    baseDamage = totalAttributes.dexterity;
                    break;
                case ClassType.Rogue:
                    baseDamage = totalAttributes.dexterity;
                    break;
                default:
                    baseDamage = 0;
                    break;
            }

            if (_equipmentSlots[EquipmentSlot.Weapon] == null)
                return 1 * (1 + baseDamage / 100);
            else
                return ((Weapon)_equipmentSlots[EquipmentSlot.Weapon]).WeaponDamage * (1 + (baseDamage / 100));
        }

        public void LevelUp()
        {
            ++Level;
            _stats += _levelUpStats;
        }
    }
}
