using Ex_003.Interfaces;

namespace Ex_003.Tests;

public class Tests
{
    private string _dataLine;
    private IFacade _facade;

    [SetUp]
    public void Setup()
    {
        _dataLine = "qwertyQWERTy";
        _facade = new Facade();
    }

    [Test]
    public void InitRucksack_IfCompartmentEqualsTempData_ReturnTrue()
    {
        var rucksack = _facade.InitRucksack(_dataLine);

        Assert.Multiple(() =>
        {
            Assert.That(rucksack.LeftCompartment.Items, Is.EqualTo(new[] {'q', 'w', 'e', 'r', 't', 'y'}));
            Assert.That(rucksack.RightCompartment.Items, Is.EqualTo(new[] {'Q', 'W', 'E', 'R', 'T', 'y'}));
        });
    }

    [Test]
    public void FindRepeatedItem_Isy_ReturnTrue()
    {
        var rucksack = _facade.InitRucksack(_dataLine);

        var repeatedItem = _facade.FindRepeatedItem(rucksack);

        Assert.That(repeatedItem, Is.EqualTo('y'));
    }

    [TestCase('D', 30)]
    [TestCase('i', 9)]
    public void GetValue_IfEquals_ReturnTrue(char item, int expectedValue)
    {
        Assert.That(_facade.GetValue(item), Is.EqualTo(expectedValue));
    }

    [Test]
    public void CreateGroups_IfTwoRucksacks_ThrowArgumentException()
    {
        
        var r1 = _facade.InitRucksack("xzzr");
        var r2 = _facade.InitRucksack("xcxu");

        Assert.That(() => _facade.CreateGroups(new[] {r1, r2}).ToList(), Throws.Exception.TypeOf<ArgumentException>());
    }
    
    [Test]
    public void FindRepeatedItem_Isx_ReturnTrue()
    {
        var group = _facade.CreateGroups(new[]
        {
            _facade.InitRucksack("xzsa"),
            _facade.InitRucksack("xcpa"),
            _facade.InitRucksack("LADx")
        });

        var repeatedItem = _facade.FindRepeatedItem(group.First());

        Assert.That(repeatedItem, Is.EqualTo('x'));
    }

    [Test]
    public void GetRepeatedItem_IfMoreThenOne_ThrowFormatException()
    {
        var rucksack = _facade.InitRucksack("zxzx");
        Assert.That(() => _facade.FindRepeatedItem(rucksack), Throws.Exception.TypeOf<FormatException>());
    }

    [Test]
    public void GetValue_IfNoLetter_ThrowArgumentException()
    {
        Assert.That(() => _facade.GetValue('%'), Throws.Exception.TypeOf<ArgumentException>());
    }
    
}