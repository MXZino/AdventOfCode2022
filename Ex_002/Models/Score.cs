using Ex_002.Enums;

namespace Ex_002.Models;

public class Score
{
    public Move OpponentMove { get; init; }
    public Move PlayerMove { get; init; }
    public BattleResult Result { get; init; }
}