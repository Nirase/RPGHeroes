using Microsoft.VisualStudio.TestTools.UnitTesting;
using RPGHeroes.Equipment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGHeroes.Equipment.Tests
{
    [TestClass]
    public class WeaponTests
    {
        [TestMethod]
        public void WeaponNameTest()
        {
            Weapon weapon = new("Common Axe", 1, 2, Enums.WeaponType.Axe);
            Assert.IsTrue(weapon.Name == "Common Axe");
        }

        [TestMethod]
        public void WeaponLevelTest()
        {
            Weapon weapon = new("Common Axe", 1, 2, Enums.WeaponType.Axe);
            Assert.IsTrue(weapon.RequiredLevel == 1);
        }

        [TestMethod]
        public void WeaponDamageTest()
        {
            Weapon weapon = new("Common Axe", 1, 2, Enums.WeaponType.Axe);
            Assert.IsTrue(weapon.WeaponDamage == 2);
        }

        [TestMethod]
        public void WeaponTypeTest()
        {
            Weapon weapon = new("Common Axe", 1, 2, Enums.WeaponType.Axe);
            Assert.IsTrue(weapon.WeaponType == Enums.WeaponType.Axe);
        }


    }
}
