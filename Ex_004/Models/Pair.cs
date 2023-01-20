namespace Ex_004.Models;

public class Pair
{
    public Pair(string dataLine)
    {
        var array = ParseElves(dataLine).ToArray();
        FirstElf = new Elf(array.ElementAt(0));
        SecondElf = new Elf(array.ElementAt(1));
    }

    public Elf FirstElf { get; }
    public Elf SecondElf { get; }

    private static IEnumerable<string> ParseElves(string dataLine)
        => dataLine.Split(',');

    public bool IsFullyContainsSectors() =>
        IsContainingSectors(FirstElf, SecondElf) ||
        IsContainingSectors(SecondElf, FirstElf);

    public bool HasOverlappingAssignment() =>
        FirstElf.StartSector <= SecondElf.StartSector
            ? FirstElf.EndSector >= SecondElf.StartSector
            : SecondElf.EndSector >= FirstElf.StartSector;

    private bool IsContainingSectors(Elf firstElf, Elf otherElf) =>
        firstElf.StartSector <= otherElf.StartSector && firstElf.EndSector >= otherElf.EndSector;
    
}