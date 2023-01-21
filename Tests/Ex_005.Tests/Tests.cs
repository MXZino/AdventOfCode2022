using Common.Models;
using Ex_005.Interfaces;
using Ex_005.Models;

namespace Ex_005.Tests;

public class Tests
{
    private Ship _ship;
    private IEx005Facade _facade;
    private IEnumerable<Move> _moves;

    [SetUp]
    public void Setup()
    {
        InitShip();
        InitFacade();
        InitMoves();
    }

    private void InitMoves()
    {
        var dataLines2 = FileDataAccess.ReadFile(@"./assets/test_data_2.txt");
        _moves = dataLines2.Select(x => new Move(x)).ToArray();
    }

    private void InitFacade()
    {
        _facade = new Ex005Facade(@"./assets/test_data_3.txt");
    }

    private void InitShip()
    {
        var dataLines = FileDataAccess.ReadFile(@"./assets/test_data.txt");
        _ship = new Ship(dataLines);
    }

    [Test]
    public void InitializeShip_IfCorrectData_ReturnTrue()
    {
        Assert.That(_ship.StackArray, Has.Length.EqualTo(3));
        
        Assert.Multiple(() =>
        {
            Assert.That(_ship.StackArray[0].ToArray().SequenceEqual(new[] { 'W', 'B', 'Z' }), Is.True);
            Assert.That(_ship.StackArray[1].ToArray().SequenceEqual(new[] { 'T', 'B' }), Is.True);
            Assert.That(_ship.StackArray[2].ToArray().SequenceEqual(new[] { 'W' }), Is.True);
        });
    }

    [Test]
    public void InitializeMove_IfCorrectData_ReturnTrue()
    {
        var moves = _moves.ToArray();
        Assert.That(moves, Has.Length.EqualTo(2));
        
        Assert.Multiple(() =>
        {
            Assert.That(moves[0].Count == 2 && moves[0].From == 8 && moves[0].To == 4, Is.True);
            Assert.That(moves[1].Count == 2 && moves[1].From == 7 && moves[1].To == 3, Is.True);
        });
    }

    [Test]
    public void PerformMove_IfCorrectData_ReturnTrue()
    {
        var move = new Move("move 2 from 1 to 2");
        
        _ship.PerformMove(move);
        
        Assert.Multiple(() =>
        {
            Assert.That(_ship.StackArray[0].ToArray().SequenceEqual(new[] { 'Z' }), Is.True);
            Assert.That(_ship.StackArray[1].ToArray().SequenceEqual(new[] {'B', 'W', 'T', 'B' }), Is.True);
            Assert.That(_ship.StackArray[2].ToArray().SequenceEqual(new[] { 'W' }), Is.True);
        });
    }

    [Test]
    public void GetValuesFromTop_IsWTW_ReturnTrue()
    {
        Assert.That(_ship.GetValuesFromTop(), Is.EqualTo("WTW"));
    }

    [Test]
    public void GetValuesFromTopOfShip_IsWVWDBNGBW_ReturnTrue()
    {
        Assert.That(_facade.GetValuesFromTopOfShip(), Is.EqualTo("WVWDBNGBW"));
    }

    [Test]
    public void PerformAdvancedMove_IfCorrectData_ReturnTrue()
    {
        var move = new Move("move 2 from 1 to 2");
        
        _ship.PerformAdvancedMove(move);
        
        Assert.Multiple(() =>
        {
            Assert.That(_ship.StackArray[0].ToArray().SequenceEqual(new[] { 'Z' }), Is.True);
            Assert.That(_ship.StackArray[1].ToArray().SequenceEqual(new[] {'W', 'B', 'T', 'B' }), Is.True);
            Assert.That(_ship.StackArray[2].ToArray().SequenceEqual(new[] { 'W' }), Is.True);
        });
    }
    
    [Test]
    public void GetValuesFromTopOfShipWithAdvancedMove_IsWVWZBNGBW_ReturnTrue()
    {
        Assert.That(_facade.GetValuesFromTopOfShipWithAdvancedMove(), Is.EqualTo("WVWZBNGBW"));
    }
}