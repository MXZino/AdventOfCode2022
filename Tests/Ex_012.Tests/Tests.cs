using Ex_012.Interfaces;

namespace Ex_012.Tests;

public class Tests
{
    private IEx012Facade _facade;
    
    [SetUp]
    public void Setup()
    {
        _facade = new Ex012Facade(@"./assets/012_test_data.txt");
    }

    [Test]
    public void GetSteps_Is31_ReturnTrue()
    {
        _facade.FindShortestWay();
        Assert.That(_facade.GetSteps(), Is.EqualTo(31));
    }
}