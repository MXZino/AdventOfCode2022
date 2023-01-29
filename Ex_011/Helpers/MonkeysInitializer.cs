using Ex_011.Models;

namespace Ex_011.Helpers;

public static class MonkeysInitializer
{
    public static List<Monkey> Initialize() =>
        new()
        {
            new Monkey
            {
                Items = new List<ulong> {89, 84, 88, 78, 70},
                Operation = x => x * 5,
                DivisibleBy = 7,
                MonkeyIndexIfDivisible = 6,
                MonkeyIndexIfNotDivisible = 7
            },
            new Monkey
            {
                Items = new List<ulong> {76, 62, 61, 54, 69, 60, 85},
                Operation = x => x + 1,
                DivisibleBy = 17,
                MonkeyIndexIfDivisible = 0,
                MonkeyIndexIfNotDivisible = 6
            },
            new Monkey
            {
                Items = new List<ulong> {83, 89, 53},
                Operation = x => x + 8,
                DivisibleBy = 11,
                MonkeyIndexIfDivisible = 5,
                MonkeyIndexIfNotDivisible = 3
            },
            new Monkey
            {
                Items = new List<ulong> {95, 94, 85, 57},
                Operation = x => x + 4,
                DivisibleBy = 13,
                MonkeyIndexIfDivisible = 0,
                MonkeyIndexIfNotDivisible = 1
            },
            new Monkey
            {
                Items = new List<ulong> {82, 98},
                Operation = x => x + 7,
                DivisibleBy = 19,
                MonkeyIndexIfDivisible = 5,
                MonkeyIndexIfNotDivisible = 2
            },
            new Monkey
            {
                Items = new List<ulong> {69},
                Operation = x => x + 2,
                DivisibleBy = 2,
                MonkeyIndexIfDivisible = 1,
                MonkeyIndexIfNotDivisible = 3
            },
            new Monkey
            {
                Items = new List<ulong> {82, 70, 58, 87, 59, 99, 92, 65},
                Operation = x => x * 11,
                DivisibleBy = 5,
                MonkeyIndexIfDivisible = 7,
                MonkeyIndexIfNotDivisible = 4
            },
            new Monkey
            {
                Items = new List<ulong> {91, 53, 96, 98, 68, 82},
                Operation = x => x * x,
                DivisibleBy = 3,
                MonkeyIndexIfDivisible = 4,
                MonkeyIndexIfNotDivisible = 2
            }
        };
}