using Ex_013.Interfaces;

namespace Ex_013.Tests;

public class Tests
{
    private IEx013Facade _facade;
        
    [SetUp]
    public void Setup()
    {
        _facade = new Ex013Facade(@"./assets/013_test_data.txt");
    }

    [Test]
    public void SumOfIndicesOfOrderedPairs_Is13_ReturnTrue() => 
        Assert.That(_facade.SumOfIndicesOfOrderedPairs(), Is.EqualTo(13));
}