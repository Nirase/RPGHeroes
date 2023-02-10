using RPGHeroes.Structs;

namespace RPGHeroes
{
    public class HeroAttributeTests
    {
        [Fact]
        public void HeroAttribute_CompareEqualAttributes_AttributesShouldMatch()
        {
            HeroAttribute attribute = new(1, 2, 3);
            HeroAttribute secondAttribute = new(1, 2, 3);
            Assert.Equal(attribute, secondAttribute);
        }
        [Fact]

        public void HeroAttribute_CompareNotEqualAttributes_AttributesShouldNotMatch()
        {
            HeroAttribute attribute = new(1, 2, 3);
            HeroAttribute secondAttribute = new(2, 3, 4);
            Assert.NotEqual(attribute, secondAttribute);
        }
    }
}
