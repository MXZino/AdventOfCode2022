using Ex_004.Models;

namespace Ex_004.Interfaces;

public interface IEx004Facade
{
    int CountFullyContainedSectors();
    int CountOverlappingAssignments();
}