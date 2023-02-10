using RPGHeroes.Equipment;
using RPGHeroes.Exceptions;
using RPGHeroes.Heroes;

namespace RPGHeroes
{
    public class HeroWeaponTests
    {
        [Fact]
        public void Hero_EquipWeapon_WeaponShouldBeEquipped()
        {
            Hero hero = new("Red", Enums.ClassType.Mage);
            Weapon weapon = new("Pokeball", 1, 3, Enums.WeaponType.Wand);
            hero.Equip(weapon);
            Assert.Equal(weapon, hero._equipmentSlots[Enums.EquipmentSlot.Weapon]);
        }

        [Fact]
        public void Hero_EquipWrongWeaponType_ShouldThrowInvalidWeaponException()
        {
            Hero hero = new("Red", Enums.ClassType.Warrior);
            Weapon weapon = new("Pokeball", 1, 3, Enums.WeaponType.Wand);
            Assert.Throws<InvalidWeaponException>(() => { hero.Equip(weapon); });
        }

        [Fact]
        public void Hero_EquipHigherLevelWeapon_ShouldThrowInvalidWeaponException()
        {
            Hero hero = new("Red", Enums.ClassType.Warrior);
            Weapon weapon = new("Pokeball", 3, 3, Enums.WeaponType.Sword);
            Assert.Throws<InvalidWeaponException>(() => { hero.Equip(weapon); });
        }
    }
}
