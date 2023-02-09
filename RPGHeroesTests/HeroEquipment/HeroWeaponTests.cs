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
    public class HeroWeaponTests
    {
        [TestMethod]
        public void HeroEquipWeaponTest()
        {
            Hero hero = new("Red", Enums.ClassType.Mage);
            Weapon weapon = new("Pokeball", 1, 3, Enums.WeaponType.Wand);
            hero.Equip(weapon);
            Assert.IsTrue(hero._equipmentSlots[Enums.EquipmentSlot.Weapon] == weapon);
        }

        [TestMethod]
        public void HeroEquipWeaponTypeFailTest()
        {
            Hero hero = new("Red", Enums.ClassType.Warrior);
            Weapon weapon = new("Pokeball", 1, 3, Enums.WeaponType.Wand);
            try
            {
                hero.Equip(weapon);
                Assert.Fail();
            }
            catch (Exception error)
            {
                Assert.IsTrue(error is InvalidWeaponException);
            }
        }

        [TestMethod]
        public void HeroEquipWeaponLevelFailTest()
        {
            Hero hero = new("Red", Enums.ClassType.Warrior);
            Weapon weapon = new("Pokeball", 3, 3, Enums.WeaponType.Sword);
            try
            {
                hero.Equip(weapon);
                Assert.Fail();
            }
            catch (Exception error)
            {
                Assert.IsTrue(error is InvalidWeaponException);
            }
        }
    }
}
