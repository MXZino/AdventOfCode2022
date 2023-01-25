using Ex_010.Interfaces;

namespace Ex_010.Models;

public class AddX : IInstruction
{
    public int Value { get; init; }
    public int CyclesPerformed { get; set; }
}