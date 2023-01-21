using Common.Extensions;

namespace Ex_005.Models;

public class Ship
{
    public Ship(IEnumerable<string> dataLines)
    {
        var dataLinesArray = dataLines.ToArray();

        var size = GetSize(dataLinesArray.Last());
        StackArray = new Stack<char>[size];
        InitStacks();
        FillStacks(dataLinesArray.Take(dataLinesArray.Length - 1));
    }

    public Stack<char>[] StackArray { get; }

    public void PerformMove(Move move)
    {
        for (var i = 0; i < move.Count; i++)
        {
            var value = StackArray[move.From - 1].Pop();
            StackArray[move.To - 1].Push(value);
        }
    }

    public void PerformAdvancedMove(Move move)
    {
        var poppedElements = PopElements(move).ToArray();

        AppendAdvancedMove(move, poppedElements);
    }

    private void AppendAdvancedMove(Move move, IReadOnlyList<char> poppedElements)
    {
        for (var i = poppedElements.Count; i > 0; i--)
            StackArray[move.To - 1].Push(poppedElements[i - 1]);
    }

    public string GetValuesFromTop() =>
        StackArray.Where(x => x.Count > 0)
            .Aggregate(string.Empty, (current, stack) => current + stack.Peek());

    private IEnumerable<char> PopElements(Move move)
    {
        for (var i = 0; i < move.Count; i++)
            yield return StackArray[move.From - 1].Pop();
    }

    private int GetSize(string dataLine) =>
        dataLine
            .Split(" ")
            .Select(x => x
                .Trim())
            .Count(x => x != string.Empty);

    private void InitStacks()
    {
        for (var i = 0; i < StackArray.Length; i++)
            StackArray[i] = new Stack<char>();
    }

    private void FillStacks(IEnumerable<string> dataLines)
    {
        var dataArray = dataLines.ToArray();

        for (var i = dataArray.Length; i > 0; i--)
            FillStacks(dataArray[i - 1]);
    }

    private void FillStacks(string dataLine)
    {
        var chunks = dataLine.Split(4).ToArray();

        for (var i = 0; i < chunks.Length; i++)
        {
            AppendCrateToStack(chunks[i].Trim(), i);
        }
    }

    private void AppendCrateToStack(string crate, int stackIndex)
    {
        try
        {
            var value = crate.SubstringBetween('[', ']');
            StackArray[stackIndex].Push(char.Parse(value));
        }
        catch (Exception)
        {
            return;
        }
    }
}