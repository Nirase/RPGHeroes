using RPGHeroes.Heroes;
using System.Globalization;

Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-US");

Console.Write("");
Hero hero = new("Super Nice Silver Sara", RPGHeroes.Enums.ClassType.Mage);
Console.WriteLine(hero.Display());