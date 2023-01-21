using Common.Models;
using Ex_005.Interfaces;
using Ex_005.Models;

namespace Ex_005;

public class Ex005Facade : IEx005Facade
{
    private readonly Ship _ship;
    private readonly IEnumerable<Move> _moves;

    public Ex005Facade(string filePath)
    {
        var dataLines = FileDataAccess.ReadFile(filePath).ToArray();
        var emptyLineIndex = FindIndexOfEmptyLine(dataLines);
        _ship = new Ship(dataLines.Take(emptyLineIndex));
        _moves = dataLines.Skip(emptyLineIndex + 1).Select(x => new Move(x));
    }

    public string GetValuesFromTopOfShip()
    {
        foreach (var move in _moves)
            _ship.PerformMove(move);
        
        return _ship.GetValuesFromTop();
    }

    public string GetValuesFromTopOfShipWithAdvancedMove()
    {
        foreach (var move in _moves)
            _ship.PerformAdvancedMove(move);
        
        return _ship.GetValuesFromTop();
    }
    
    private int FindIndexOfEmptyLine(IEnumerable<string> dataLines)
    {
        var array = dataLines.ToArray();
        var index = 0;

        for (var i = 0; i < array.Length; i++)
        {
            if (!string.IsNullOrEmpty(array[i].Trim())) 
                continue;
            
            index = i;
            break;
        }

        return index;
    }
}