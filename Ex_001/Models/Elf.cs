namespace Ex_001.Models;

public record Elf
{
    public List<int> Calories { get; } = new();

    public Elf(params int[] calories)
    {
        foreach (var value in calories)
            Calories.Add(value);
    }
}
    