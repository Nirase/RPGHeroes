using Microsoft.VisualStudio.TestTools.UnitTesting;
using RPGHeroes.Structs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGHeroes
{
    [TestClass]
    public class HeroAttributeTests
    {
        [TestMethod]
        public void HeroAttribute_CompareEqualAttributes_AttributesShouldMatch()
        {
            HeroAttribute attribute = new(1, 2, 3);
            HeroAttribute secondAttribute = new(1, 2, 3);
            Assert.IsTrue(attribute == secondAttribute);
        }
        [TestMethod]

        public void HeroAttribute_CompareNotEqualAttributes_AttributesShouldNotMatch()
        {
            HeroAttribute attribute = new(1, 2, 3);
            HeroAttribute secondAttribute = new(2, 3, 4);
            Assert.IsTrue(attribute != secondAttribute);
        }
    }
}
