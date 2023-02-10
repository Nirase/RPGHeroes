namespace RPGHeroes.Equipment.Tests
{
    public class ArmorTests
    {
        [Fact]
        public void Armor_NameConstructor_ShouldMatchInput()
        {
            Armor armor = new("Common Plate Chest", 1, new Structs.HeroAttribute(1, 0, 0), Enums.EquipmentSlot.Body, Enums.ArmorType.Plate);
            Assert.Equal("Common Plate Chest", armor.Name);
        }

        [Fact]
        public void Armor_LevelConstructor_ShouldMatchInput()
        {
            Armor armor = new("Common Plate Chest", 1, new Structs.HeroAttribute(1, 0, 0), Enums.EquipmentSlot.Body, Enums.ArmorType.Plate);
            Assert.Equal(1, armor.RequiredLevel);
        }

        [Fact]
        public void Armor_HeroAttributesConstructor_ShouldMatchInput()
        {
            Armor armor = new("Common Plate Chest", 1, new Structs.HeroAttribute(1, 0, 0), Enums.EquipmentSlot.Body, Enums.ArmorType.Plate);
            Assert.Equal(new Structs.HeroAttribute(1, 0, 0), armor.ArmorAttribute);
        }

        [Fact]
        public void Armor_TypeConstructor_ShouldMatchInput()
        {
            Armor armor = new("Common Plate Chest", 1, new Structs.HeroAttribute(1, 0, 0), Enums.EquipmentSlot.Body, Enums.ArmorType.Plate);
            Assert.Equal(Enums.ArmorType.Plate, armor.ArmorType);
        }

        [Fact]
        public void Armor_SlotConstructor_ShouldMatchInput()
        {
            Armor armor = new("Common Plate Chest", 1, new Structs.HeroAttribute(1, 0, 0), Enums.EquipmentSlot.Body, Enums.ArmorType.Plate);
            Assert.Equal(Enums.EquipmentSlot.Body, armor.Slot);
        }



    }
}
