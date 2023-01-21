using Ex_006.Interfaces;

namespace Ex_006.Tests;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void GetBeginPacketPosition_Is5_ReturnTrue()
    {
        IEx006Facade facade = new Ex006Facade(@"./assets/006_test_data.txt");
        
        Assert.That(facade.GetBeginPacketPosition(), Is.EqualTo(5));
    }

    [Test]
    public void GetBeginPacketPosition_InvalidData_ThrowException()
    {
        IEx006Facade facade = new Ex006Facade(@"./assets/006_test_data_2.txt");
        
        Assert.That(() => facade.GetBeginPacketPosition(), Throws.Exception.TypeOf<ArgumentException>());
    }

    [Test]
    public void GetStartOfMessagePosition_Is23_ReturnTrue()
    {
        IEx006Facade facade = new Ex006Facade(@"./assets/006_test_data.txt");
        
        Assert.That(facade.GetStartOfMessagePosition(), Is.EqualTo(23));
    }
    
    [Test]
    public void GetStartOfMessagePosition()
    {
        IEx006Facade facade = new Ex006Facade(@"./assets/006_test_data_2.txt");
        
        Assert.That(() => facade.GetStartOfMessagePosition(), Throws.Exception.TypeOf<ArgumentException>());
    }
}