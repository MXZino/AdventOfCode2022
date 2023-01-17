using Ex_002.Enums;
using Ex_002.Interfaces;

namespace Ex_002.Models;

public abstract class DataAccessBase : IDataAccess
{
    protected abstract string FilePath { get; }

    public Tuple<Player, Player> ReadDataAsMoves()
    {
        var opponent = new Player();
        var player = new Player();

        foreach (var line in File.ReadLines(FilePath))
            ParseMoves(line,opponent,player);

        return new Tuple<Player, Player>(opponent, player);
    }

    public Tuple<Player, Player> ReadDataAsScores()
    {
        var opponent = new Player();
        var player = new Player();

        foreach (var line in File.ReadLines(FilePath))
            ParseMovesAsPlayerScore(line,opponent,player);

        return new Tuple<Player, Player>(opponent, player);
    }
    
    private void ParseMoves(string line, Player opponent, Player player)
    {
        var elements = line.Split(" ");
        opponent.Moves.Add(ParseOpponentMoves(elements.First()));
        player.Moves.Add(ParsePlayerMoves(elements.Last()));
    }

    private void ParseMovesAsPlayerScore(string line, Player opponent, Player player)
    {
        var elements = line.Split(" ");
        var opponentMove = ParseOpponentMoves(elements.First());
        opponent.Moves.Add(opponentMove);
        player.Moves.Add(ParsePlayerScore(opponentMove,elements.Last()));
    }

    private Move ParseOpponentMoves(string move) =>
        move switch
        {
            "A" => Move.Rock,
            "B" => Move.Paper,
            "C" => Move.Scissors,
            _ => throw new ArgumentException()
        };

    private Move ParsePlayerMoves(string move) =>
        move switch
        {
            "X" => Move.Rock,
            "Y" => Move.Paper,
            "Z" => Move.Scissors,
            _ => throw new ArgumentException()
        };

    private Move ParsePlayerScore(Move opponentMove, string move) =>
        (opponentMove, move) switch
        {
            (Move.Paper, "X") => Move.Rock,
            (Move.Paper, "Y") => Move.Paper,
            (Move.Paper, "Z") => Move.Scissors,
            (Move.Rock, "X") => Move.Scissors,
            (Move.Rock, "Y") => Move.Rock,
            (Move.Rock, "Z") => Move.Paper,
            (Move.Scissors, "X") => Move.Paper,
            (Move.Scissors, "Y") => Move.Scissors,
            (Move.Scissors, "Z") => Move.Rock,
            _ => throw new ArgumentOutOfRangeException()
        };
}