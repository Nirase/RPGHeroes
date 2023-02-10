using RPGHeroes.Equipment;
using RPGHeroes.Exceptions;
using RPGHeroes.Heroes;

namespace RPGHeroes
{
    public class HeroArmorTests
    {
        [Fact]
        public void Hero_EquipArmor_ArmorShouldBeEquipped()
        {
            Hero hero = new("Red", Enums.ClassType.Mage);
            Armor armor = new("Common Cloth Chest", 1, new Structs.HeroAttribute(1, 0, 0), Enums.EquipmentSlot.Body, Enums.ArmorType.Cloth);
            hero.Equip(armor);
            Assert.Equal(armor, hero._equipmentSlots[Enums.EquipmentSlot.Body]);
        }

        [Fact]
        public void Hero_EquipWrongArmorType_ShouldThrowInvalidArmorException()
        {
            Hero hero = new("Red", Enums.ClassType.Warrior);
            Armor armor = new("Common Cloth Chest", 1, new Structs.HeroAttribute(1, 0, 0), Enums.EquipmentSlot.Body, Enums.ArmorType.Cloth);
            Assert.Throws<InvalidArmorException>(() => { hero.Equip(armor); });
        }

        [Fact]
        public void Hero_EquipHigherLevelArmorType_ShouldThrowInvalidArmorException()
        {
            Hero hero = new("Red", Enums.ClassType.Warrior);
            Armor armor = new("Common Cloth Chest", 1, new Structs.HeroAttribute(1, 0, 0), Enums.EquipmentSlot.Body, Enums.ArmorType.Cloth);
            Assert.Throws<InvalidArmorException>(() => { hero.Equip(armor); });
        }

    }
}
