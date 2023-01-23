using Ex_009.Enums;

namespace Ex_009.Models;

public class Move
{
    public MoveDirection Direction { get; }
    public byte Steps { get; }

    public Move(string dataLine)
    {
        var chunks = dataLine.Trim().Split(" ");
        Direction = ParseDirection(chunks[0]);
        Steps = byte.Parse(chunks[1]);
    }

    private MoveDirection ParseDirection(string move) =>
        move switch
        {
            "R" => MoveDirection.Right,
            "U" => MoveDirection.Up,
            "L" => MoveDirection.Left,
            "D" => MoveDirection.Down,
            _ => throw new ArgumentOutOfRangeException(nameof(move), move, null)
        };
}