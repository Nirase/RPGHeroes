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
    public class ArmorTests
    {
        [TestMethod]
        public void Armor_NameConstructor_ShouldMatchInput()
        {
            Armor armor = new("Common Plate Chest", 1, new Structs.HeroAttribute(1, 0, 0), Enums.EquipmentSlot.Body, Enums.ArmorType.Plate);
            Assert.IsTrue(armor.Name == "Common Plate Chest");
        }

        [TestMethod]
        public void Armor_LevelConstructor_ShouldMatchInput()
        {
            Armor armor = new("Common Plate Chest", 1, new Structs.HeroAttribute(1, 0, 0), Enums.EquipmentSlot.Body, Enums.ArmorType.Plate);
            Assert.IsTrue(armor.RequiredLevel == 1);
        }

        [TestMethod]
        public void Armor_HeroAttributesConstructor_ShouldMatchInput()
        {
            Armor armor = new("Common Plate Chest", 1, new Structs.HeroAttribute(1, 0, 0), Enums.EquipmentSlot.Body, Enums.ArmorType.Plate);
            Assert.IsTrue(armor.ArmorAttribute == new Structs.HeroAttribute(1, 0, 0));
        }

        [TestMethod]
        public void Armor_TypeConstructor_ShouldMatchInput()
        {
            Armor armor = new("Common Plate Chest", 1, new Structs.HeroAttribute(1, 0, 0), Enums.EquipmentSlot.Body, Enums.ArmorType.Plate);
            Assert.IsTrue(armor.ArmorType == Enums.ArmorType.Plate);
        }

        [TestMethod]
        public void Armor_SlotConstructor_ShouldMatchInput()
        {
            Armor armor = new("Common Plate Chest", 1, new Structs.HeroAttribute(1, 0, 0), Enums.EquipmentSlot.Body, Enums.ArmorType.Plate);
            Assert.IsTrue(armor.Slot == Enums.EquipmentSlot.Body);
        }



    }
}
