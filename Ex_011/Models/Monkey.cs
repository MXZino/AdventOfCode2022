namespace Ex_011.Models;

public class Monkey
{
    public required List<ulong> Items { get; set; }
    public required ulong DivisibleBy { get; init; }
    public required int MonkeyIndexIfDivisible { get; init; }
    public required int MonkeyIndexIfNotDivisible { get; init; }
    public required Func<ulong, ulong> Operation { get; init; }
    public ulong? DivideWorryLevel { get; set; }

    private int _operationsCounter;

    public void AddItem(ulong item) => Items.Add(item);

    public IEnumerable<ThrownItem> InspectItems()
    {
        foreach (var item in Items)
            yield return InspectItem(item);

        Items.Clear();
    }

    public int GetOperationsCounter() => _operationsCounter;

    private ThrownItem InspectItem(ulong item)
    {
        _operationsCounter += 1;

        var worryLevel = Operation(item);

        if (DivideWorryLevel == null)
            worryLevel = (ulong) Math.Floor(worryLevel / 3.0);
        else
            worryLevel %= DivideWorryLevel.Value;


        return new ThrownItem
        {
            Item = worryLevel,
            MonkeyIndex = worryLevel % DivisibleBy == 0 ? MonkeyIndexIfDivisible : MonkeyIndexIfNotDivisible
        };
    }
}