using Ex_015.Interfaces;

namespace Ex_015.Tests;

public class Tests
{
    private IEx015Facade _facade;
    
    [SetUp]
    public void Setup()
    {
        _facade = new Ex015Facade("./assets/015_test_data.txt");
    }

    [Test]
    public void TestGetPositionsWithoutBeacon_Is26_ReturnTrue()
    {
        Assert.That(_facade.GetPositionsWithoutBeacon(10), Is.EqualTo(26));
    }
}