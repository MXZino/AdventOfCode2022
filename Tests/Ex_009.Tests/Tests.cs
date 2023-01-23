using Ex_009.Interfaces;

namespace Ex_009.Tests;

public class Tests
{
    
    [Test]
    public void CountTailUniquePositionsWith2Knots_Is13_ReturnTrue()
    {
        var facade = new Ex009Facade(@"./assets/009_test_data.txt", 2);
        facade.PerformMoves();
        Assert.That(facade.CountTailUniquePositions(), Is.EqualTo(13));
    }

    [Test]
    public void CountTailUniquePositionsWith10Knots_Is36_ReturnTrue()
    {
        var facade = new Ex009Facade(@"./assets/009_test_data_2.txt", 10);
        facade.PerformMoves();
        Assert.That(facade.CountTailUniquePositions(), Is.EqualTo(36));
    }
}