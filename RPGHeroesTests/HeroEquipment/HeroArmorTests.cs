using Microsoft.VisualStudio.TestTools.UnitTesting;
using RPGHeroes.Equipment;
using RPGHeroes.Exceptions;
using RPGHeroes.Heroes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGHeroes
{
    [TestClass]
    public class HeroArmorTests
    {
        [TestMethod]
        public void HeroEquipArmorTest()
        {
            Hero hero = new("Red", Enums.ClassType.Mage);
            Armor armor = new("Common Cloth Chest", 1, new Structs.HeroAttribute(1, 0, 0), Enums.EquipmentSlot.Body, Enums.ArmorType.Cloth);
            hero.Equip(armor);
            Assert.IsTrue(hero._equipmentSlots[Enums.EquipmentSlot.Body] == armor);
        }

        [TestMethod]
        public void HeroEquipArmorTypeFailTest()
        {
            Hero hero = new("Red", Enums.ClassType.Warrior);
            Armor armor = new("Common Cloth Chest", 1, new Structs.HeroAttribute(1, 0, 0), Enums.EquipmentSlot.Body, Enums.ArmorType.Cloth);
            try
            {
                hero.Equip(armor);
                Assert.Fail();
            }
            catch (Exception error)
            {
                Assert.IsTrue(error is InvalidArmorException);
            }

        }

        [TestMethod]
        public void HeroEquipArmorLevelFailTest()
        {
            Hero hero = new("Red", Enums.ClassType.Warrior);
            Armor armor = new("Common Cloth Chest", 1, new Structs.HeroAttribute(1, 0, 0), Enums.EquipmentSlot.Body, Enums.ArmorType.Cloth);
            try
            {
                hero.Equip(armor);
                Assert.Fail();
            }
            catch (Exception error)
            {
                Assert.IsTrue(error is InvalidArmorException);
            }
        }

    }
}
