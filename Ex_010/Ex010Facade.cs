using Common.Models;
using Ex_010.Interfaces;
using Ex_010.Models;

namespace Ex_010;

public class Ex010Facade : IEx010Facade
{
    private readonly IEnumerable<IInstruction> _instructions;

    public Ex010Facade(string filePath)
    {
        var dataLines = FileDataAccess.ReadFile(filePath);
        _instructions = ParseData(dataLines);
    }

    public int GetSumOfSignalStrength(int[] cyclesToReturn)
    {
        var signals = PerformCycles(cyclesToReturn).ToArray();

        return signals.Select((t, i) => cyclesToReturn[i] * t).Sum();
    }

    public IEnumerable<char> ProduceImage()
    {
        var spriteMiddlePosition = 1;
        var cyclesCounter = 0;

        foreach (var instruction in _instructions)
        {
            switch (instruction)
            {
                case Noop:
                    yield return DrawPixel(spriteMiddlePosition, cyclesCounter);
                    cyclesCounter += 1;
                    break;
                case AddX addX:
                    while (addX.CyclesPerformed < 2)
                    {
                        yield return DrawPixel(spriteMiddlePosition, cyclesCounter);
                        addX.CyclesPerformed += 1;
                        cyclesCounter += 1;
                    }

                    spriteMiddlePosition += addX.Value;
                    break;
            }
        }
    }

    private static char DrawPixel(int spriteMiddlePosition, int cyclesCounter)
    {
        if (spriteMiddlePosition == cyclesCounter % 40
            || spriteMiddlePosition - 1 == cyclesCounter % 40
            || spriteMiddlePosition + 1 == cyclesCounter % 40)
            return '#';
        
        return '.';
    }

    private IEnumerable<IInstruction> ParseData(IEnumerable<string> dataLines) => dataLines.Select(ParseData);

    private IInstruction ParseData(string dataLine)
    {
        if (dataLine.StartsWith("noop"))
            return new Noop();

        var chunks = dataLine.Split(" ");

        return new AddX
        {
            Value = int.Parse(chunks[1])
        };
    }

    private IEnumerable<int> PerformCycles(int[] cyclesToReturn)
    {
        var xValue = 1;
        var cyclesCounter = 0;

        foreach (var instruction in _instructions)
        {
            switch (instruction)
            {
                case Noop:
                    cyclesCounter += 1;
                    if (cyclesToReturn.Contains(cyclesCounter))
                        yield return xValue;
                    break;
                case AddX addX:
                    while (addX.CyclesPerformed < 2)
                    {
                        addX.CyclesPerformed += 1;
                        cyclesCounter += 1;
                        
                        if (cyclesToReturn.Contains(cyclesCounter))
                            yield return xValue;
                    }

                    xValue += addX.Value;
                    break;
            }
        }
    }
}