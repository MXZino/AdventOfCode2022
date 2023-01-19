namespace Ex_003.Models;

public class Rucksack
{
    public Compartment LeftCompartment { get; init; }
    public Compartment RightCompartment { get; init; }

    public IEnumerable<char> GetAllItems() => 
        LeftCompartment.Items.Concat(RightCompartment.Items);
}