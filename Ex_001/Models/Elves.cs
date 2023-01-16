using Ex_001.Interfaces;

namespace Ex_001.Models;

public class Elves
{
    private readonly IDataAccess _dataAccess;

    public Elves(IDataAccess dataAccess)
    {
        _dataAccess = dataAccess;
        ReadData();
    }

    public Elf[] ElfArray { get; private set; }

    private void ReadData() => ElfArray = _dataAccess.ReadElves().ToArray();

    public int GetMaxTotalCalories() => ElfArray.Select(x => x.Calories.Sum()).Max();

    public int GetSumCaloriesOfTopThreeElves() =>
        ElfArray
            .Select(x => x.Calories.Sum())
            .OrderDescending()
            .Take(3)
            .Sum();
}