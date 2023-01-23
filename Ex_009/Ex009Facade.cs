using Common.Models;
using Ex_009.Enums;
using Ex_009.Interfaces;
using Ex_009.Models;

namespace Ex_009;

public class Ex009Facade : IEx009Facade
{
    private readonly IEnumerable<Move> _moves;
    private readonly Position[] _knotsPositions;
    private readonly HashSet<Position> _tailUniquePositions;

    public Ex009Facade(string filePath, int knots)
    {
        var dataLines = FileDataAccess.ReadFile(filePath);
        _moves = dataLines.Select(x => new Move(x));
        _knotsPositions = new Position[knots];
        InitializeKnots();
        _tailUniquePositions = new HashSet<Position> {new(0, 0)};
    }

    private void InitializeKnots()
    {
        for (var i = 0; i < _knotsPositions.Length; i++)
            _knotsPositions[i] = new Position(0, 0);
    }

    public void PerformMoves()
    {
        foreach (var move in _moves)
            PerformMove(move);
    }

    public int CountTailUniquePositions() => _tailUniquePositions.Count;

    private void PerformMove(Move move)
    {
        for (var i = 0; i < move.Steps; i++)
            PerformStep(move);
    }

    private void PerformStep(Move move)
    {
        for (var i = 0; i < _knotsPositions.Length; i++)
        {
            if (i == 0)
            {
                PerformHeadMove(move.Direction, _knotsPositions[i]);
                continue;
            }

            if (IsAdjacent(_knotsPositions[i], _knotsPositions[i - 1]))
                break;
            
            PerformTailMove(_knotsPositions[i], _knotsPositions[i-1]);
            
            if (i == _knotsPositions.Length - 1)
                _tailUniquePositions.Add(_knotsPositions[i]);
        }
    }

    private void PerformHeadMove(MoveDirection direction, Position headPosition)
    {
        switch (direction)
        {
            case MoveDirection.Up:
                headPosition.Top += 1;
                break;
            case MoveDirection.Down:
                headPosition.Top -= 1;
                break;
            case MoveDirection.Left:
                headPosition.Right -= 1;
                break;
            case MoveDirection.Right:
                headPosition.Right += 1;
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(direction), direction, null);
        }
    }

    private bool IsAdjacent(Position currentKnot, Position previousKnot) =>
        Math.Abs(previousKnot.Top - currentKnot.Top) <= 1 &&
        Math.Abs(previousKnot.Right - currentKnot.Right) <= 1;

    private void PerformTailMove(Position currentKnot, Position previousKnot)
    {

        var topDifference = previousKnot.Top - currentKnot.Top;
        var rightDifference = previousKnot.Right - currentKnot.Right;

        switch (topDifference)
        {
            case > 0:
                currentKnot.Top += 1;
                break;
            case < 0:
                currentKnot.Top -= 1;
                break;
        }

        switch (rightDifference)
        {
            case > 0:
                currentKnot.Right += 1;
                break;
            case < 0:
                currentKnot.Right -= 1;
                break;
        }
    }
    
}