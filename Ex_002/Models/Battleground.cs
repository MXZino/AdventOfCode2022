using Ex_002.Enums;

namespace Ex_002.Models;

public class Battleground
{
    public static Score Battle(Move opponentMove, Move playerMove)
    {
        return new Score
        {
            Result = ResolveBattle(opponentMove, playerMove),
            OpponentMove = opponentMove,
            PlayerMove = playerMove
        };
    }

    private static BattleResult ResolveBattle(Move opponentMove, Move playerMove) =>
        (opponentMove, playerMove) switch
        {
            (Move.Rock, Move.Rock) => BattleResult.Draw,
            (Move.Rock, Move.Paper) => BattleResult.Win,
            (Move.Rock, Move.Scissors) => BattleResult.Lose,
            (Move.Paper, Move.Rock) => BattleResult.Lose,
            (Move.Paper, Move.Paper) => BattleResult.Draw,
            (Move.Paper, Move.Scissors) => BattleResult.Win,
            (Move.Scissors, Move.Rock) => BattleResult.Win,
            (Move.Scissors, Move.Paper) => BattleResult.Lose,
            (Move.Scissors, Move.Scissors) => BattleResult.Draw,
            _ => throw new ArgumentOutOfRangeException()
        };

    public static int CountPlayerPoints(IEnumerable<Score> scores) =>
        scores
            .Aggregate(0, (current, score) => current + (int) score.Result + (int) score.PlayerMove);
}