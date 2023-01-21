using Common.Models;
using Ex_004.Interfaces;
using Ex_004.Models;

namespace Ex_004;

public class Ex004Facade : IEx004Facade
{
    private readonly IEnumerable<Pair> _pairs;

    public Ex004Facade(string filePath)
    {
        var dataLines = FileDataAccess.ReadFile(filePath);
        _pairs = dataLines.Select(x => new Pair(x));
    }

    public int CountFullyContainedSectors() => 
        _pairs
            .Select(x=> x
                .IsFullyContainsSectors())
            .Count(x => x);

    public int CountOverlappingAssignments() =>
        _pairs
            .Select(x => x
                .HasOverlappingAssignment())
            .Count(x => x);
}