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
        var players = dataAccess.ReadDataAsMoves();
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
    
    
    [TestCase(Move.Paper, Move.Paper)]
    [TestCase(Move.Rock, Move.Rock)]
    [TestCase(Move.Scissors, Move.Scissors)]
    public void Battle_IsDrawResult(Move opponentMove, Move playerMove)
    {
        var result = Battleground.Battle(opponentMove, playerMove);
        Assert.That(result.Result, Is.EqualTo(BattleResult.Draw));
    }
    
    [TestCase(Move.Paper, Move.Scissors)]
    [TestCase(Move.Rock, Move.Paper)]
    [TestCase(Move.Scissors, Move.Rock)]
    public void Battle_IsWinResult(Move opponentMove, Move playerMove)
    {
        var result = Battleground.Battle(opponentMove, playerMove);
        Assert.That(result.Result, Is.EqualTo(BattleResult.Win));
    }
    
    [TestCase(Move.Paper, Move.Rock)]
    [TestCase(Move.Rock, Move.Scissors)]
    [TestCase(Move.Scissors, Move.Paper)]
    public void Battle_IsLoseResult(Move opponentMove, Move playerMove)
    {
        var result = Battleground.Battle(opponentMove, playerMove);
        Assert.That(result.Result, Is.EqualTo(BattleResult.Lose));
    }

    [Test]
    public void CountPlayerPoints_Is12_ReturnTrue()
    {
        var scores = new List<Score>
        {
            new()
            {
                Result = BattleResult.Win,
                PlayerMove = Move.Rock,
                OpponentMove = Move.Scissors
            },
            new()
            {
                Result = BattleResult.Draw,
                PlayerMove = Move.Paper,
                OpponentMove = Move.Paper
            }
        };

        var points = Battleground.CountPlayerPoints(scores);
        Assert.That(points, Is.EqualTo(12));
    } 
}