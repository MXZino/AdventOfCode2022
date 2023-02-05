using Ex_014.Interfaces;

namespace Ex_014.Tests;

public class Tests
{
    private IEx014Facade _facade;
        
    [SetUp]
    public void Setup()
    {
        _facade = new Ex014Facade("./assets/014_test_data.txt");
    }

    [Test]
    public void GetUnitsOfSand_Is24_ReturnTrue()
    {
        _facade = new Ex014Facade("./assets/014_test_data.txt");
      Assert.That(_facade.GetUnitsOfSand(), Is.EqualTo(24));
    }
    
    [Test]
    public void GetUnitsOfSandWithFloor_Is93_ReturnTrue()
    {
        _facade = new Ex014Facade("./assets/014_test_data.txt");
        Assert.That(_facade.GetUnitsOfSandWithFloor(), Is.EqualTo(93));
    }
}