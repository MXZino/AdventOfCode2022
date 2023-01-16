using Ex_001.Interfaces;

namespace Ex_001.Models;

public abstract class DataAccessBase : IDataAccess
{
    protected abstract string FilePath { get; }
    
    public IEnumerable<Elf> ReadElves()
    {
        var elves = new List<Elf>();
        var elf = new Elf();
        
        foreach (var line in File.ReadLines(FilePath))
        {
            if (string.IsNullOrEmpty(line))
            {
                AppendElf(elves, ref elf);
                continue;
            }
            
            elf.Calories.Add(int.Parse(line));
        }
        
        if(elf.Calories.Any())
            AppendElf(elves, ref elf);

        return elves;
    }

    private void AppendElf(ICollection<Elf> elves, ref Elf elf)
    {
        elves.Add(elf);
        elf = new Elf();
    }
}