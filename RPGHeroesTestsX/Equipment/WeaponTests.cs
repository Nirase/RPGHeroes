namespace RPGHeroes.Equipment.Tests
{
    public class WeaponTests
    {
        [Fact]
        public void Weapon_NameConstructor_ShouldMatchInput()
        {
            Weapon weapon = new("Common Axe", 1, 2, Enums.WeaponType.Axe);
            Assert.Equal("Common Axe", weapon.Name);
        }

        [Fact]
        public void Weapon_LevelConstructor_ShouldMatchInput()
        {
            Weapon weapon = new("Common Axe", 1, 2, Enums.WeaponType.Axe);
            Assert.Equal(1, weapon.RequiredLevel);
        }

        [Fact]
        public void Weapon_DamageConstructor_ShouldMatchInput()
        {
            Weapon weapon = new("Common Axe", 1, 2, Enums.WeaponType.Axe);
            Assert.Equal(2, weapon.WeaponDamage);
        }

        [Fact]
        public void Weapon_TypeConstructor_ShouldMatchInput()
        {
            Weapon weapon = new("Common Axe", 1, 2, Enums.WeaponType.Axe);
            Assert.Equal(Enums.WeaponType.Axe, weapon.WeaponType);
        }


    }
}
