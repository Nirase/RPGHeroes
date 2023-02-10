using Microsoft.VisualStudio.TestTools.UnitTesting;
using RPGHeroes.Equipment;
using RPGHeroes.Heroes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGHeroes.Heroes.Tests
{
    [TestClass()]
    public class HeroTests
    {
        [TestMethod()]
        public void Hero_NameInConstructor_ShouldBeSetToInput()
        {
            Hero hero = new("Vex", Enums.ClassType.Ranger);
            Assert.IsTrue(hero.Name == "Vex");
        }

        [TestMethod()]
        public void Hero_TypeInConstructor_ShouldBeSetToInput()
        {
            Hero hero = new("Vax", Enums.ClassType.Rogue);
            Assert.IsTrue(hero.ClassType == Enums.ClassType.Rogue);
        }

        [TestMethod]
        public void Hero_LevelInConstructor_ShouldBeSetToInput()
        {
            Hero hero = new("Conan", Enums.ClassType.Warrior);
            Assert.IsTrue(hero.Level == 1);
        }

        [TestMethod]
        public void Hero_HeroAttributeInConstructor_ShouldBeSetToInput()
        {
            Hero hero = new("CatHero", Enums.ClassType.Mage);
            Assert.IsTrue(hero.Stats == new Structs.HeroAttribute(1, 1, 8));
        }

        [TestMethod]
        public void Hero_LevelUp_StatsShouldMatchLevel()
        {
            Hero hero = new("Merlin", Enums.ClassType.Mage);
            hero.LevelUp();
            Assert.IsTrue(hero.Stats == new Structs.HeroAttribute(2, 2, 13));
        }

        [TestMethod]
        public void Hero_LevelUp_LevelShouldMatchNewLevel()
        {
            Hero hero = new("Legolas", Enums.ClassType.Ranger);
            hero.LevelUp();
            Assert.IsTrue(hero.Level == 2);
        }

        [TestMethod]
        public void Hero_TotalAttributesWithNoEquipment_ShouldMatchHeroStats()
        {
            Hero hero = new(" ", Enums.ClassType.Warrior);
            Assert.IsTrue(hero.TotalAttributes() == new Structs.HeroAttribute(5, 2, 1));
        }

        [TestMethod]
        public void Hero_TotalAttributesWithOneArmor_ShouldMatchHeroStatsPlusArmor()
        {
            Hero hero = new("Ande", Enums.ClassType.Warrior);
            Armor armor = new("Common Plate Chest", 1, new Structs.HeroAttribute(1, 0, 0), Enums.EquipmentSlot.Body, Enums.ArmorType.Plate);
            hero.Equip(armor);
            Assert.IsTrue(hero.TotalAttributes() == new Structs.HeroAttribute(6, 2, 1));
        }

        [TestMethod]
        public void Hero_TotalAttributesWithTwoArmor_ShouldMatchHeroStatsPlusArmor()
        {
            Hero hero = new("Eran", Enums.ClassType.Warrior);
            Armor body = new("Common Plate Chest", 1, new Structs.HeroAttribute(1, 0, 0), Enums.EquipmentSlot.Body, Enums.ArmorType.Plate);
            Armor legs = new("Common Plate Legs", 1, new Structs.HeroAttribute(1, 0, 0), Enums.EquipmentSlot.Legs, Enums.ArmorType.Plate);
            hero.Equip(body);
            hero.Equip(legs);
            Assert.IsTrue(hero.TotalAttributes() == new Structs.HeroAttribute(7, 2, 1));
        }

        [TestMethod]
        public void Hero_TotalAttributesWithThreeArmor_ShouldMatchHeroStatsPlusArmor()
        {
            Hero hero = new("Lorin", Enums.ClassType.Warrior);
            Armor body = new("Common Plate Chest", 1, new Structs.HeroAttribute(1, 0, 0), Enums.EquipmentSlot.Body, Enums.ArmorType.Plate);
            Armor legs = new("Common Plate Legs", 1, new Structs.HeroAttribute(1, 0, 0), Enums.EquipmentSlot.Legs, Enums.ArmorType.Plate);
            Armor head = new("Common Plate Head", 1, new Structs.HeroAttribute(1, 0, 0), Enums.EquipmentSlot.Head, Enums.ArmorType.Plate);
            hero.Equip(body);
            hero.Equip(legs);
            hero.Equip(head);
            Assert.IsTrue(hero.TotalAttributes() == new Structs.HeroAttribute(8, 2, 1));
        }

        [TestMethod]
        public void Hero_TotalAttributesWithReplacedArmor_ShouldMatchHeroStatsPlusArmor()
        {
            Hero hero = new("Indi", Enums.ClassType.Warrior);
            Armor body = new("Common Plate Chest", 1, new Structs.HeroAttribute(1, 0, 0), Enums.EquipmentSlot.Body, Enums.ArmorType.Plate);
            Armor replacementBody = new("Common Plate Chest", 1, new Structs.HeroAttribute(3, 0, 0), Enums.EquipmentSlot.Body, Enums.ArmorType.Plate);
            hero.Equip(body);
            hero.Equip(replacementBody);
            Assert.IsTrue(hero.TotalAttributes() == new Structs.HeroAttribute(8, 2, 1));
        }

        [TestMethod]
        public void Hero_DamageWithNoWeapon_ShouldMatchBaseDamage()
        {
            Hero hero = new(" ", Enums.ClassType.Ranger);
            Assert.IsTrue(hero.Damage() == 1.07d);
        }

        [TestMethod]
        public void Hero_DamageWithWeapon_ShouldMatchDamageWithWeapon()
        {
            Hero hero = new("Legolas", Enums.ClassType.Ranger);
            Weapon weapon = new("Common bow", 1, 2, Enums.WeaponType.Bow);
            hero.Equip(weapon);
            Assert.IsTrue(hero.Damage() == 2.14d);
        }

        [TestMethod]
        public void Hero_DamageWithWeaponReplaced_ShouldMatchDamageWithWeapon()
        {
            Hero hero = new("Legolas", Enums.ClassType.Ranger);
            Weapon weapon = new("Common bow", 1, 2, Enums.WeaponType.Bow);
            Weapon replacementWeapon = new("Common bow", 1, 4, Enums.WeaponType.Bow);
            hero.Equip(weapon);
            hero.Equip(replacementWeapon);
            Assert.IsTrue(hero.Damage() == 4.28d);
        }

        [TestMethod]
        public void Hero_DamageWithWeaponAndArmor_ShouldMatchDamageWithWeaponAndBonusStats()
        {
            Hero hero = new("Legolas", Enums.ClassType.Ranger);
            Weapon weapon = new("Common bow", 1, 2, Enums.WeaponType.Bow);
            Armor body = new("Common Leather Chest", 1, new Structs.HeroAttribute(0, 1, 0), Enums.EquipmentSlot.Body, Enums.ArmorType.Leather);
            Armor legs = new("Common Leather Legs", 1, new Structs.HeroAttribute(0, 2, 0), Enums.EquipmentSlot.Legs, Enums.ArmorType.Leather);
            Armor head = new("Common Leather Head", 1, new Structs.HeroAttribute(0, 1, 0), Enums.EquipmentSlot.Head, Enums.ArmorType.Leather);
            hero.Equip(weapon);
            hero.Equip(body);
            hero.Equip(legs);
            hero.Equip(head);
            Assert.IsTrue(hero.Damage() == 2.22d);
        }
    }
}