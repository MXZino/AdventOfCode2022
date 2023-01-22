using Ex_008.Interfaces;

namespace Ex_008.Tests;

public class Tests
{
    private IEx008Facade _facade;
    
    [SetUp]
    public void Setup()
    {
        _facade = new Ex008Facade(@"./assets/008_test_data.txt");
    }

    [Test]
    public void CountVisibleTrees_Is21_ReturnTrue()
    {
        Assert.That(_facade.CountVisibleTrees(), Is.EqualTo(21));
    }

    [Test]
    public void GetHighestScenicScore_Is8_ReturnTrue()
    {
        Assert.That(_facade.GetHighestScenicScore(), Is.EqualTo(8));
    }
}