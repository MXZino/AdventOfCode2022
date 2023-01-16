using Ex_002.Enums;
using Ex_002.Interfaces;

namespace Ex_002.Models;

public abstract class DataAccessBase : IDataAccess
{
    protected abstract string FilePath { get; }

    public Tuple<Player, Player> ReadPlayers()
    {
        var opponent = new Player();
        var player = new Player();

        foreach (var line in File.ReadLines(FilePath))
            ParseMoves(line,opponent,player);

        return new Tuple<Player, Player>(opponent, player);
    }

    private void ParseMoves(string line, Player opponent, Player player)
    {
        var elements = line.Split(" ");
        opponent.Moves.Add(ParseOpponentMoves(elements.First()));
        player.Moves.Add(ParsePlayerMoves(elements.Last()));
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
}