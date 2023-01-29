using Ex_011.Interfaces;
using Ex_011.Models;

namespace Ex_011;

public class Ex011Facade : IEx011Facade
{
    private readonly List<Monkey> _monkeys;
    private readonly bool _divideWorryLevels;

    public Ex011Facade(List<Monkey> monkeys, bool divideWorryLevels)
    {
        _monkeys = monkeys;
        _divideWorryLevels = divideWorryLevels;
    }

    public void PerformRounds(int rounds)
    {
        SetDivideWorryLevels();
        
        for (var i = 0; i < rounds; i++)
        {
            PerformRound();
        }
    }

    private void SetDivideWorryLevels()
    {
        if (_divideWorryLevels) return;
        
        var factorLevel = _monkeys
            .Select(x=> x.DivisibleBy)
            .Aggregate((ulong)1, (x, y) => x * y);
        
        foreach (var monkey in _monkeys)
            monkey.DivideWorryLevel = factorLevel;
    }

    public ulong GetLevelOfMonkeyBusiness() =>
        _monkeys
            .Select(x => x
                .GetOperationsCounter())
            .OrderDescending()
            .Take(2)
            .Select(x=> (ulong)x)
            .Aggregate((ulong)1, (x, y) => x * y);

    private void PerformRound()
    {
        foreach (var item in _monkeys
                     .Select(monkey => monkey
                         .InspectItems())
                     .SelectMany(inspectedItems => inspectedItems))
            _monkeys.ElementAt(item.MonkeyIndex).AddItem(item.Item);
    }
    
}