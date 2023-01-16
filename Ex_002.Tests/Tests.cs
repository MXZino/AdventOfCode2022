using Ex_002.Enums;
using Ex_002.Models;

namespace Ex_002.Tests;

public class Tests
{
    private Player _player;
    private Player _opponent;
    [SetUp]
    public void Setup()
    {
        var dataAccess = new MockedFileDataAccess();
        var players = dataAccess.ReadPlayers();
        _opponent = players.Item1;
        _player = players.Item2;
    }

    [Test]
    public void CreatePlayers_VerifyCorrectParse()
    {
        Assert.Multiple(() =>
        {
            Assert.That(_player.Moves, Has.Count.EqualTo(6));
            Assert.That(_opponent.Moves, Has.Count.EqualTo(6));
        });

        var opponentMoves = new List<Move> {Move.Scissors, Move.Scissors, Move.Paper, Move.Rock, Move.Paper, Move.Rock};
        var playerMoves = new List<Move> {Move.Paper, Move.Paper, Move.Paper, Move.Scissors, Move.Scissors, Move.Rock};
        
        Assert.Multiple(() =>
        {
            Assert.That(_opponent.Moves, Is.EqualTo(opponentMoves));
            Assert.That(_player.Moves, Is.EqualTo(playerMoves));
        });
    }
}