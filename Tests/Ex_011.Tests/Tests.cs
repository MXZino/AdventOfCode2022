using Ex_011.Interfaces;
using Ex_011.Models;

namespace Ex_011.Tests;

public class Tests
{
    private List<Monkey> _monkeys;

    [SetUp]
    public void Setup()
    {
        _monkeys = new List<Monkey>
        {
            new()
            {
                Items = new List<ulong> {79, 98},
                Operation = x => x * 19,
                DivisibleBy = 23,
                MonkeyIndexIfDivisible = 2,
                MonkeyIndexIfNotDivisible = 3
            },
            new()
            {
                Items = new List<ulong> {54, 65, 75, 74},
                Operation = x => x + 6,
                DivisibleBy = 19,
                MonkeyIndexIfDivisible = 2,
                MonkeyIndexIfNotDivisible = 0
            },
            new()
            {
                Items = new List<ulong> {79, 60, 97},
                Operation = x => x * x,
                DivisibleBy = 13,
                MonkeyIndexIfDivisible = 1,
                MonkeyIndexIfNotDivisible = 3
            },
            new()
            {
                Items = new List<ulong> {74},
                Operation = x => x + 3,
                DivisibleBy = 17,
                MonkeyIndexIfDivisible = 0,
                MonkeyIndexIfNotDivisible = 1
            }
        };
        
    }

    [Test]
    public void GetLevelOfMonkeyBusiness_Is10605_ReturnTrue()
    {
        IEx011Facade facade = new Ex011Facade(_monkeys, true);
        facade.PerformRounds(20);
        Assert.That(facade.GetLevelOfMonkeyBusiness(), Is.EqualTo(10605));
    }
    
    [Test]
    public void GetLevelOfMonkeyBusinessWithoutDivide_Is2713310158_ReturnTrue()
    {
        IEx011Facade facade = new Ex011Facade(_monkeys, false);
        facade.PerformRounds(10000);
        Assert.That(facade.GetLevelOfMonkeyBusiness(), Is.EqualTo(2713310158));
    }
}