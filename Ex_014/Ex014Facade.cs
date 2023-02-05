using Common.Models;
using Ex_014.Interfaces;
using Ex_014.Models;

namespace Ex_014;

public class Ex014Facade : IEx014Facade
{
    private Cave _cave;

    public Ex014Facade(string filePath)
    {
        _cave = new Cave(1000, 1000);
        
        var dataLines = FileDataAccess.ReadFile(filePath);
        var rockLines = dataLines.Select(x => new RockLine(x));

        foreach (var rockLine in rockLines)
            rockLine.DrawRocks(_cave);
    }

    public int GetUnitsOfSand()
    {
        _cave.FallSand();
        
        var unitsOfSand = 0;
        
        for (var row = 0; row < 1000; row++)
        {
            for (var column = 0; column < 1000; column++)
            {
                if (_cave.Map[column, row] == 'O')
                    unitsOfSand += 1;
            }
        }

        return unitsOfSand;
    }

    public int GetUnitsOfSandWithFloor()
    {
        _cave.DrawFloor();
        _cave.FallSand();
        return GetUnitsOfSand();
    }
}