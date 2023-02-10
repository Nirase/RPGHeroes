using RPGHeroes.Equipment;
using RPGHeroes.Heroes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace RPGHeroesTestsX.Heroes
{
    public class HeroTests
    {
        [Fact]
        public void Hero_NameInConstructor_ShouldBeSetToInput()
        {
            Hero hero = new("Vex", RPGHeroes.Enums.ClassType.Ranger);
            Assert.Equal("Vex", hero.Name);
        }

        [Fact]
        public void Hero_TypeInConstructor_ShouldBeSetToInput()
        {
            Hero hero = new("Vax", RPGHeroes.Enums.ClassType.Rogue);
            Assert.Equal(RPGHeroes.Enums.ClassType.Rogue, hero.ClassType);
        }

        [Fact]
        public void Hero_LevelInConstructor_ShouldBeSetToInput()
        {
            Hero hero = new("Conan", RPGHeroes.Enums.ClassType.Warrior);
            Assert.Equal(1, hero.Level);
        }

        [Fact]
        public void Hero_HeroAttributeInConstructor_ShouldBeSetToInput()
        {
            Hero hero = new("CatHero", RPGHeroes.Enums.ClassType.Mage);
            Assert.Equal(new RPGHeroes.Structs.HeroAttribute(1, 1, 8), hero.Stats);
        }

        [Fact]
        public void Hero_LevelUp_StatsShouldMatchLevel()
        {
            Hero hero = new("Merlin", RPGHeroes.Enums.ClassType.Mage);
            hero.LevelUp();
            Assert.Equal(new RPGHeroes.Structs.HeroAttribute(2, 2, 13), hero.Stats);
        }

        [Fact]
        public void Hero_LevelUp_LevelShouldMatchNewLevel()
        {
            Hero hero = new("Legolas", RPGHeroes.Enums.ClassType.Ranger);
            hero.LevelUp();
            Assert.Equal(2, hero.Level);
        }

        [Fact]
        public void Hero_TotalAttributesWithNoEquipment_ShouldMatchHeroStats()
        {
            Hero hero = new(" ", RPGHeroes.Enums.ClassType.Warrior);
            Assert.Equal(new RPGHeroes.Structs.HeroAttribute(5, 2, 1), hero.TotalAttributes());
        }

        [Fact]
        public void Hero_TotalAttributesWithOneArmor_ShouldMatchHeroStatsPlusArmor()
        {
            Hero hero = new("Ande", RPGHeroes.Enums.ClassType.Warrior);
            Armor armor = new("Common Plate Chest", 1, new RPGHeroes.Structs.HeroAttribute(1, 0, 0), RPGHeroes.Enums.EquipmentSlot.Body, RPGHeroes.Enums.ArmorType.Plate);
            hero.Equip(armor);
            Assert.Equal(new RPGHeroes.Structs.HeroAttribute(6, 2, 1), hero.TotalAttributes());
        }

        [Fact]
        public void Hero_TotalAttributesWithTwoArmor_ShouldMatchHeroStatsPlusArmor()
        {
            Hero hero = new("Eran", RPGHeroes.Enums.ClassType.Warrior);
            Armor body = new("Common Plate Chest", 1, new RPGHeroes.Structs.HeroAttribute(1, 0, 0), RPGHeroes.Enums.EquipmentSlot.Body, RPGHeroes.Enums.ArmorType.Plate);
            Armor legs = new("Common Plate Legs", 1, new RPGHeroes.Structs.HeroAttribute(1, 0, 0), RPGHeroes.Enums.EquipmentSlot.Legs, RPGHeroes.Enums.ArmorType.Plate);
            hero.Equip(body);
            hero.Equip(legs);
            Assert.Equal(new RPGHeroes.Structs.HeroAttribute(7, 2, 1), hero.TotalAttributes());
        }

        [Fact]
        public void Hero_TotalAttributesWithThreeArmor_ShouldMatchHeroStatsPlusArmor()
        {
            Hero hero = new("Lorin", RPGHeroes.Enums.ClassType.Warrior);
            Armor body = new("Common Plate Chest", 1, new RPGHeroes.Structs.HeroAttribute(1, 0, 0), RPGHeroes.Enums.EquipmentSlot.Body, RPGHeroes.Enums.ArmorType.Plate);
            Armor legs = new("Common Plate Legs", 1, new RPGHeroes.Structs.HeroAttribute(1, 0, 0), RPGHeroes.Enums.EquipmentSlot.Legs, RPGHeroes.Enums.ArmorType.Plate);
            Armor head = new("Common Plate Head", 1, new RPGHeroes.Structs.HeroAttribute(1, 0, 0), RPGHeroes.Enums.EquipmentSlot.Head, RPGHeroes.Enums.ArmorType.Plate);
            hero.Equip(body);
            hero.Equip(legs);
            hero.Equip(head);
            Assert.Equal(new RPGHeroes.Structs.HeroAttribute(8, 2, 1), hero.TotalAttributes());
        }

        [Fact]
        public void Hero_TotalAttributesWithReplacedArmor_ShouldMatchHeroStatsPlusArmor()
        {
            Hero hero = new("Indi", RPGHeroes.Enums.ClassType.Warrior);
            Armor body = new("Common Plate Chest", 1, new RPGHeroes.Structs.HeroAttribute(1, 0, 0), RPGHeroes.Enums.EquipmentSlot.Body, RPGHeroes.Enums.ArmorType.Plate);
            Armor replacementBody = new("Common Plate Chest", 1, new RPGHeroes.Structs.HeroAttribute(3, 0, 0), RPGHeroes.Enums.EquipmentSlot.Body, RPGHeroes.Enums.ArmorType.Plate);
            hero.Equip(body);
            hero.Equip(replacementBody);
            Assert.Equal(new RPGHeroes.Structs.HeroAttribute(8, 2, 1), hero.TotalAttributes());
        }

        [Fact]
        public void Hero_DamageWithNoWeapon_ShouldMatchBaseDamage()
        {
            Hero hero = new(" ", RPGHeroes.Enums.ClassType.Ranger);
            Assert.Equal(1.07d, hero.Damage());
        }

        [Fact]
        public void Hero_DamageWithWeapon_ShouldMatchDamageWithWeapon()
        {
            Hero hero = new("Legolas", RPGHeroes.Enums.ClassType.Ranger);
            Weapon weapon = new("Common bow", 1, 2, RPGHeroes.Enums.WeaponType.Bow);
            hero.Equip(weapon);
            Assert.Equal(2.14d, hero.Damage());
        }

        [Fact]
        public void Hero_DamageWithWeaponReplaced_ShouldMatchDamageWithWeapon()
        {
            Hero hero = new("Legolas", RPGHeroes.Enums.ClassType.Ranger);
            Weapon weapon = new("Common bow", 1, 2, RPGHeroes.Enums.WeaponType.Bow);
            Weapon replacementWeapon = new("Common bow", 1, 4, RPGHeroes.Enums.WeaponType.Bow);
            hero.Equip(weapon);
            hero.Equip(replacementWeapon);
            Assert.Equal(4.28d, hero.Damage());
        }

        [Fact]
        public void Hero_DamageWithWeaponAndArmor_ShouldMatchDamageWithWeaponAndBonusStats()
        {
            Hero hero = new("Legolas", RPGHeroes.Enums.ClassType.Ranger);
            Weapon weapon = new("Common bow", 1, 2, RPGHeroes.Enums.WeaponType.Bow);
            Armor body = new("Common Leather Chest", 1, new RPGHeroes.Structs.HeroAttribute(0, 1, 0), RPGHeroes.Enums.EquipmentSlot.Body, RPGHeroes.Enums.ArmorType.Leather);
            Armor legs = new("Common Leather Legs", 1, new RPGHeroes.Structs.HeroAttribute(0, 2, 0), RPGHeroes.Enums.EquipmentSlot.Legs, RPGHeroes.Enums.ArmorType.Leather);
            Armor head = new("Common Leather Head", 1, new RPGHeroes.Structs.HeroAttribute(0, 1, 0), RPGHeroes.Enums.EquipmentSlot.Head, RPGHeroes.Enums.ArmorType.Leather);
            hero.Equip(weapon);
            hero.Equip(body);
            hero.Equip(legs);
            hero.Equip(head);
            Assert.Equal(2.22d, hero.Damage());
        }
    }
}