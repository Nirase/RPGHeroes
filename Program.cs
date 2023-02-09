// See https://aka.ms/new-console-template for more information
using RPGHeroes.Enums;
using RPGHeroes.Equipment;
using RPGHeroes.Heroes;
using RPGHeroes.Structs;

Console.WriteLine("Hello, World!");
var mage = new Hero("Eren", RPGHeroes.Enums.ClassType.Mage);
var warrior = new Hero("Conan", RPGHeroes.Enums.ClassType.Warrior);
var rogue = new Hero("Vax", RPGHeroes.Enums.ClassType.Rogue);
var ranger = new Hero("Vex", RPGHeroes.Enums.ClassType.Ranger);

TestBase("Eren", RPGHeroes.Enums.ClassType.Mage, mage);
TestBase("Conan", RPGHeroes.Enums.ClassType.Warrior, warrior);
TestBase("Vax", RPGHeroes.Enums.ClassType.Rogue, rogue);
TestBase("Vex", RPGHeroes.Enums.ClassType.Ranger, ranger);
Console.WriteLine("Base stats correct");

TestLevelUp(RPGHeroes.Enums.ClassType.Mage, mage);
TestLevelUp(RPGHeroes.Enums.ClassType.Warrior, warrior);
TestLevelUp(RPGHeroes.Enums.ClassType.Rogue, rogue);
TestLevelUp(RPGHeroes.Enums.ClassType.Ranger, ranger);
Console.WriteLine("Level up stats correct");

var axe = new Weapon("Common Axe", 1, 2, RPGHeroes.Enums.WeaponType.Axe);
var axeHighLevel = new Weapon("Uncommon Axe", 20, 30, RPGHeroes.Enums.WeaponType.Axe);

TestWeaponCreation("Common Axe", 1, 2, WeaponType.Axe, axe);
Console.WriteLine("Weapon creation correct");

var plate = new Armor("Common Plate Chest", 1, new HeroAttribute(1, 0, 0), EquipmentSlot.Body, ArmorType.Plate);
var plateHighLevel = new Armor("Uncommon Plate Chest", 20, new HeroAttribute(30, 0, 0), EquipmentSlot.Body, ArmorType.Plate);

TestArmorCreation("Common Plate Chest", 1, new HeroAttribute(1, 0, 0), ArmorType.Plate, EquipmentSlot.Body, plate);
Console.WriteLine("Armor creation correct");

TestEquipWeapon(warrior, axe);
TestEquipWeapon(mage, axe);
TestEquipWeapon(warrior, axeHighLevel);
Console.WriteLine("Equip Weapon test pass");

TestEquipArmor(warrior, plate);
TestEquipArmor(mage, plate);
TestEquipArmor(warrior, plateHighLevel);
Console.WriteLine("Equip Armor test pass");

TestTotalAttributes();
Console.WriteLine("Total attributes test passed");

TestDamage();
Console.WriteLine("Damage test passed");

TestDisplay();

void TestBase(string enteredName, RPGHeroes.Enums.ClassType enteredClass, Hero testHero)
{
    if (enteredName != testHero.Name)
        throw new Exception("Name is not correct");
    if (enteredClass != testHero.ClassType)
        throw new Exception("Class is not correct");
    if (testHero.Level != 1)
        throw new Exception("Base level is not correct");

    switch (enteredClass)
    {
        case RPGHeroes.Enums.ClassType.Mage:
            if (testHero.BaseStats != new RPGHeroes.Structs.HeroAttribute(1, 1, 8) || testHero.Stats != new RPGHeroes.Structs.HeroAttribute(1, 1, 8))
                throw new Exception("Base attributes is not correct");
            break;
        case RPGHeroes.Enums.ClassType.Warrior:
            if (testHero.BaseStats != new RPGHeroes.Structs.HeroAttribute(5, 2, 1) || testHero.Stats != new RPGHeroes.Structs.HeroAttribute(5, 2, 1))
                throw new Exception("Base attributes is not correct");
            break;
        case RPGHeroes.Enums.ClassType.Rogue:
            if (testHero.BaseStats != new RPGHeroes.Structs.HeroAttribute(2, 6, 1) || testHero.Stats != new RPGHeroes.Structs.HeroAttribute(2, 6, 1))
                throw new Exception("Base attributes is not correct");
            break;
        case RPGHeroes.Enums.ClassType.Ranger:
            if (testHero.BaseStats != new RPGHeroes.Structs.HeroAttribute(1, 7, 1) || testHero.Stats != new RPGHeroes.Structs.HeroAttribute(1, 7, 1))
                throw new Exception("Base attributes is not correct");
            break;
        default:
            throw new Exception("Hero initialized without a class");
    }
}

void TestLevelUp(RPGHeroes.Enums.ClassType enteredClass, Hero testHero)
{
    testHero.LevelUp();
    switch (enteredClass)
    {
        case RPGHeroes.Enums.ClassType.Mage:
            if (testHero.Stats != new RPGHeroes.Structs.HeroAttribute(2, 2, 13))
                throw new Exception("Level up did not apply stats correctly");
            break;
        case RPGHeroes.Enums.ClassType.Warrior:
            if (testHero.Stats != new RPGHeroes.Structs.HeroAttribute(8, 4, 2))
                throw new Exception("Level up did not apply stats correctly");
            break;
        case RPGHeroes.Enums.ClassType.Rogue:
            if (testHero.Stats != new RPGHeroes.Structs.HeroAttribute(3, 10, 2))
                throw new Exception("Level up did not apply stats correctly");
            break;
        case RPGHeroes.Enums.ClassType.Ranger:
            if (testHero.BaseStats != new RPGHeroes.Structs.HeroAttribute(1, 7, 1) || testHero.Stats != new RPGHeroes.Structs.HeroAttribute(2, 12, 2))
                throw new Exception("Level up did not apply stats correctly");
            break;
        default:
            throw new Exception("Hero initialized without a class");
    }
}

void TestWeaponCreation(string enteredName, int enteredLevel, int enteredDamage, WeaponType enteredType, Weapon testWeapon)
{
    if (enteredName != testWeapon.Name)
        throw new Exception("Weapon did not set name correctly");
    if (enteredLevel != testWeapon.RequiredLevel)
        throw new Exception("Weapon did not set required level correctly");
    if (enteredDamage != testWeapon.WeaponDamage)
        throw new Exception("Weapon did not set weapon damage correctly");
    if (enteredType != testWeapon.WeaponType)
        throw new Exception("Weapon did not set weapon type correctly");
    if (testWeapon.Slot != EquipmentSlot.Weapon)
        throw new Exception("Weapon did not set slot correctly");
}

void TestArmorCreation(string enteredName, int enteredLevel, HeroAttribute enteredAttributes, ArmorType enteredType, EquipmentSlot enteredSlot, Armor testArmor)
{
    if (enteredName != testArmor.Name)
        throw new Exception("Armor did not set name correctly");
    if (enteredLevel != testArmor.RequiredLevel)
        throw new Exception("Armor did not set required level correctly");
    if (enteredAttributes != testArmor.ArmorAttribute)
        throw new Exception("Armor did not set weapon damage correctly");
    if (enteredType != testArmor.ArmorType)
        throw new Exception("Armor did not set weapon type correctly");
    if (testArmor.Slot != enteredSlot)
        throw new Exception("Armor did not set slot correctly");
}

void TestEquipWeapon(Hero testHero, Weapon testWeapon)
{
    try
    {
        testHero.Equip(testWeapon);

    }
    catch (Exception error)
    {
        Console.WriteLine(error.Message);
        return;

    }

    if (testHero._equipmentSlots[EquipmentSlot.Weapon] != testWeapon)
        throw new Exception("Weapon did not equip");

}

void TestEquipArmor(Hero testHero, Armor testArmor)
{
    try
    {
        testHero.Equip(testArmor);

    }
    catch (Exception error)
    {
        Console.WriteLine(error.Message);
        return;
    }

    if (testHero._equipmentSlots[testArmor.Slot] != testArmor)
        throw new Exception("Weapon did not equip");

}

void TestTotalAttributes()
{
    if (mage.TotalAttributes() != new HeroAttribute(2, 2, 13))
        throw new Exception("Total attributes not correct on base");
    if (warrior.TotalAttributes() != new HeroAttribute(9, 4, 2))
        throw new Exception("Total attributes not correct with one armor piece");
    Armor headPiece = new Armor("Common Cap", 2, new HeroAttribute(2, 1, 0), EquipmentSlot.Head, ArmorType.Mail);
    warrior.Equip(headPiece);
    if (warrior.TotalAttributes() != new HeroAttribute(11, 5, 2))
        throw new Exception("Total attributes not correct with two armor pieces");

    Armor replaceHeadPiece = new("More common cap", 1, new HeroAttribute(1, 0, 0), EquipmentSlot.Head, ArmorType.Mail);
    warrior.Equip(replaceHeadPiece);
    if (warrior.TotalAttributes() != new HeroAttribute(10, 4, 2))
        throw new Exception("Total attributes not correct with replaced armor pieces");

}

void TestDamage()
{
    Hero hero = new Hero("CatHero", ClassType.Mage);

    if (hero.Damage() != 1.08d)
        throw new Exception("Base damage is not correct");
    Weapon wand = new Weapon("Wand", 1, 2, WeaponType.Wand);
    hero.Equip(wand);
    if (hero.Damage() != 2.16d)
        throw new Exception("Weapon damage is not correct");
    Weapon staff = new Weapon("Staff", 1, 4, WeaponType.Staff);
    hero.Equip(staff);
    if (hero.Damage() != 4.32d)
        throw new Exception("Replaced weapon damage is not correct");
}

void TestDisplay()
{
    Hero hero = new Hero("DogHero", ClassType.Warrior);

    var axe = new Weapon("Common Axe", 1, 2, RPGHeroes.Enums.WeaponType.Axe);

    hero.Equip(axe);

    hero.Display();
}