namespace Ex_004.Models;

public class Elf
{
    public Elf(string dataLine)
    {
        var array = ParseSectors(dataLine).ToArray();
        StartSector = int.Parse(array.ElementAt(0));
        EndSector = int.Parse(array.ElementAt(1));
    }
    
    public int StartSector { get; }
    public int EndSector { get; }

    private static IEnumerable<string> ParseSectors(string dataLine) 
        => dataLine.Split('-');
}