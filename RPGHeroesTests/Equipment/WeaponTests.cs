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
        public void Weapon_NameConstructor_ShouldMatchInput()
        {
            Weapon weapon = new("Common Axe", 1, 2, Enums.WeaponType.Axe);
            Assert.IsTrue(weapon.Name == "Common Axe");
        }

        [TestMethod]
        public void Weapon_LevelConstructor_ShouldMatchInput()
        {
            Weapon weapon = new("Common Axe", 1, 2, Enums.WeaponType.Axe);
            Assert.IsTrue(weapon.RequiredLevel == 1);
        }

        [TestMethod]
        public void Weapon_DamageConstructor_ShouldMatchInput()
        {
            Weapon weapon = new("Common Axe", 1, 2, Enums.WeaponType.Axe);
            Assert.IsTrue(weapon.WeaponDamage == 2);
        }

        [TestMethod]
        public void Weapon_TypeConstructor_ShouldMatchInput()
        {
            Weapon weapon = new("Common Axe", 1, 2, Enums.WeaponType.Axe);
            Assert.IsTrue(weapon.WeaponType == Enums.WeaponType.Axe);
        }


    }
}
