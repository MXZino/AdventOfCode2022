using Ex_001.Models;

namespace Ex_001.Tests;

public class Tests
{
    private Elves _elves;
    
    [SetUp]
    public void Setup()
    {
        var dataAccess = new MockedFileDataAccess();
        _elves = new Elves(dataAccess);
    }

    [Test]
    public void CreateElves_VerifyCorrectParse()
    {
        var elfArray = new Elf[]
        {
            new(100, 200, 300),
            new(500),
            new(100, 1000)
        };
        
        Assert.That(_elves.ElfArray, Has.Length.EqualTo(4));
        
        Assert.Multiple(() =>
        {
            Assert.That(_elves.ElfArray[0].Calories, Is.EqualTo(elfArray[0].Calories));
            Assert.That(_elves.ElfArray[1].Calories, Is.EqualTo(elfArray[1].Calories));
            Assert.That(_elves.ElfArray[2].Calories, Is.EqualTo(elfArray[2].Calories));
        });
    }

    [Test]
    public void GetMaxTotalCalories_Is6000_ReturnTrue() => 
        Assert.That(_elves.GetMaxTotalCalories(), Is.EqualTo(6000));

    [Test]
    public void GetSumCaloriesOfTopThreeElves_Is7700_ReturnTrue() =>
        Assert.That(_elves.GetSumCaloriesOfTopThreeElves(), Is.EqualTo(7700));
}