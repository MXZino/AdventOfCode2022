using Ex_003.Models;

namespace Ex_003.Interfaces;

public interface IFacade
{
    Rucksack InitRucksack(string line);
    char FindRepeatedItem(Rucksack rucksack);
    char FindRepeatedItem(Group group);
    int GetValue(char item);
    IEnumerable<Group> CreateGroups(IEnumerable<Rucksack> rucksacks);
}