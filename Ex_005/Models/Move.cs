namespace Ex_005.Models;

public class Move
{
    public Move(string dataLine)
    {
        var array = ParseDataLine(dataLine).ToArray();
        
        Count = array[0];
        From = array[1];
        To = array[2];
    }

    public int Count { get; }
    public int From { get; }
    public int To { get; }

    private IEnumerable<int> ParseDataLine(string dataLine) =>
        dataLine
            .Replace("move", string.Empty)
            .Replace("from", ",")
            .Replace("to", ",")
            .Replace(" ", string.Empty)
            .Split(',')
            .Select(int.Parse);
}