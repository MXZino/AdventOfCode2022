namespace Ex_014.Models;

public class RockLine
{
    private readonly Tuple<int,int>[] _cornerPositions;

    public RockLine(string dataLine)
    {
        _cornerPositions = dataLine
            .Split("->")
            .Select(x => x.Trim())
            .Select(x=> x.Split(',').Select(int.Parse))
            .Select(x=>
            {
                var array = x as int[] ?? x.ToArray();
                return new Tuple<int, int>(array.ElementAt(0), array.ElementAt(1));
            })
            .ToArray();
    }

    public void DrawRocks(Cave cave)
    {
        for (var i = 0; i < _cornerPositions.Length - 1; i++)
        {
            var firstCorner = _cornerPositions[i];
            var secondCorner = _cornerPositions[i + 1];

            if (firstCorner.Item1 == secondCorner.Item1)
                DrawVertical(cave, 
                    firstCorner.Item2 > secondCorner.Item2 ? secondCorner.Item2 : firstCorner.Item2, 
                    secondCorner.Item2 > firstCorner.Item2 ? secondCorner.Item2 : firstCorner.Item2, 
                    firstCorner.Item1);
            else
                DrawHorizontal(cave,                     
                    firstCorner.Item1 > secondCorner.Item1 ? secondCorner.Item1 : firstCorner.Item1, 
                    secondCorner.Item1 > firstCorner.Item1 ? secondCorner.Item1 : firstCorner.Item1, 
                    firstCorner.Item2);
        }
    }

    private void DrawVertical(Cave cave, int startPosition, int endPosition, int column)
    {
        for (var i = startPosition; i <= endPosition; i++)
        {
            cave.Map[i, column] = '#';
        }
    }


    private void DrawHorizontal(Cave cave, int startPosition, int endPosition, int row)
    {
        for (var i = startPosition; i <= endPosition; i++)
        {
            cave.Map[row, i] = '#';
        }
    }
}