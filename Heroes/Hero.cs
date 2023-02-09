using RPGHeroes.Enums;
using RPGHeroes.Equipment;
using RPGHeroes.Interfaces;
using RPGHeroes.Managers;
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
        

        public Hero(string name, ClassType classType)
        {
            this.Name = name;
            this._classType = classType;
            this.Level = 1;
            EquipmentManager.AddHero(this);
            switch (classType) 
            {
                case ClassType.Mage:
                    EquipmentManager.SetAllowedWeapons(this, new WeaponType[] { WeaponType.Staff, WeaponType.Wand });
                    EquipmentManager.SetAllowedArmor(this, new ArmorType[] { ArmorType.Cloth });
                    _baseStats = new(1, 1, 8);
                    _stats = new(_baseStats);
                    _levelUpStats = new(1, 1, 5);
                    break;
                case ClassType.Warrior:
                    EquipmentManager.SetAllowedWeapons(this, new WeaponType[] { WeaponType.Axe, WeaponType.Sword, WeaponType.Hammer });
                    EquipmentManager.SetAllowedArmor( this, new ArmorType[] { ArmorType.Mail, ArmorType.Plate });
                    _baseStats = new(5, 2, 1);
                    _stats = new(_baseStats);
                    _levelUpStats = new(3, 2, 1);
                    break;
                case ClassType.Ranger:
                    EquipmentManager.SetAllowedWeapons(this, new WeaponType[] { WeaponType.Bow });
                    EquipmentManager.SetAllowedArmor(this, new ArmorType[] { ArmorType.Leather, ArmorType.Mail });
                    _baseStats = new(1, 7, 1);
                    _stats = new(_baseStats);
                    _levelUpStats = new(1, 5, 1);
                    break;
                case ClassType.Rogue:
                    EquipmentManager.SetAllowedWeapons(this, new WeaponType[] { WeaponType.Dagger, WeaponType.Sword });
                    EquipmentManager.SetAllowedArmor(this, new ArmorType[] { ArmorType.Leather, ArmorType.Mail });
                    _baseStats = new(2, 6, 1);
                    _stats = new(_baseStats);
                    _levelUpStats = new(1, 4, 1);
                    break;
                default:
                    EquipmentManager.SetAllowedArmor(this, new ArmorType[0]);
                    EquipmentManager.SetAllowedWeapons(this, new WeaponType[0]);
                    _baseStats = new(0, 0, 0);
                    _stats = new(_baseStats);
                    _levelUpStats = new(0, 0, 0);
                    break;
            }
        }


        public void Equip(IEquippable equippable)
        {
            EquipmentManager.Equip(this, equippable);
        }
        public HeroAttribute TotalAttributes()
        {
            var result = new HeroAttribute(_stats);
            foreach(var value in EquipmentManager.GetAllEquipment(this).Values)
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

            if (EquipmentManager.GetEquippable(this, EquipmentSlot.Weapon) == null)
                return 1 * (1 + baseDamage / 100);
            else
                return ((Weapon)EquipmentManager.GetEquippable(this, EquipmentSlot.Weapon)).WeaponDamage * (1 + (baseDamage / 100));
        }

        public void LevelUp()
        {
            ++Level;
            _stats += _levelUpStats;
        }
    }
}
