using Ex_010.Interfaces;

namespace Ex_010.Tests;

public class Tests
{
    private IEx010Facade _facade;
    
    [SetUp]
    public void Setup()
    {
        _facade = new Ex010Facade(@"./assets/010_test_data.txt");
    }

    [Test]
    public void GetSumOfSignalStrength_Is13140_ReturnTrue()
    {
        var value = _facade.GetSumOfSignalStrength(new[] {20, 60, 100, 140, 180, 220});
        Assert.That(value, Is.EqualTo(13140));
    }

    [Test]
    public void ProduceImage_HasSpecificPattern_ReturnTrue()
    {
        var pixels = _facade.ProduceImage();

        var firstRowPixels = pixels.Take(40).ToArray();
        
        Assert.That(firstRowPixels, Is.EqualTo("##..##..##..##..##..##..##..##..##..##.."));
    }
}