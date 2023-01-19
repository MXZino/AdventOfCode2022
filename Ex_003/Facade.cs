using Ex_003.Interfaces;
using Ex_003.Models;

namespace Ex_003;

public class Facade : IFacade
{
    public Rucksack InitRucksack(string line) =>
        new()
        {
            LeftCompartment = CreateCompartment(line[..(line.Length / 2)]),
            RightCompartment = CreateCompartment(line[(line.Length / 2)..])
        };

    public char FindRepeatedItem(Rucksack rucksack)
    {
        var repeatedItems = rucksack.LeftCompartment.Items.Intersect(rucksack.RightCompartment.Items).ToArray();

        return GetRepeatedItem(repeatedItems);
    }

    private static char GetRepeatedItem(IReadOnlyCollection<char> repeatedItems)
    {
        if (repeatedItems.Count > 1 || !repeatedItems.Any())
            throw new FormatException();

        return repeatedItems.First();
    }

    public char FindRepeatedItem(Group group)
    {
        var repeatedItems = group.Rucksacks.ElementAt(0).GetAllItems()
            .Intersect(group.Rucksacks.ElementAt(1).GetAllItems())
            .Intersect(group.Rucksacks.ElementAt(2).GetAllItems())
            .ToArray();
        
        return GetRepeatedItem(repeatedItems);
    }

    public int GetValue(char item)
    {
        var value = (int) item;

        return value switch
        {
            >= 65 and <= 90 => value - 38,
            >= 97 and <= 122 => value - 96,
            _ => throw new ArgumentException()
        };
    }


    public IEnumerable<Group> CreateGroups(IEnumerable<Rucksack> rucksacks)
    {
        var rucksackArray = rucksacks.ToArray();

        if (rucksackArray.Length % 3 != 0)
            throw new ArgumentException();

        for (var i = 0; i < rucksackArray.Length / 3; i++)
            yield return new Group
            {
                Rucksacks = new[]
                {
                    rucksackArray[i * 3],
                    rucksackArray[i * 3 + 1],
                    rucksackArray[i * 3 + 2]
                }
            };
    }

    private static Compartment CreateCompartment(string line) =>
        new()
        {
            Items = line
        };
}