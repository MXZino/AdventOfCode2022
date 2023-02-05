namespace Ex_014.Models;

public class Cave
{
    public char[,] Map { get; }

    public Cave(int width, int height)
    {
        Map = new char[width, height];
    }

    public void FallSand()
    {
        try
        {
            while (true)
            {
                PerformFalling(0, 500);
            }
        }
        catch
        {
            Console.WriteLine("End of fall");
        }
    }

    private void PerformFalling(int row, int column)
    {
        if (Map[row, column] == 'O')
            throw new Exception();

        while (true)
        {
            if (Map[row + 1, column] != '#' && Map[row + 1, column] != 'O')
            {
                row += 1;
                continue;
            }

            if (Map[row + 1, column - 1] != '#' && Map[row + 1, column - 1] != 'O')
            {
                column -= 1;
                row += 1;
                continue;
            }

            if (Map[row + 1, column + 1] != '#' && Map[row + 1, column + 1] != 'O')
            {
                column += 1;
                row += 1;
                continue;
            }

            Map[row, column] = 'O';

            break;
        }
    }

    public void DrawFloor()
    {
        var highestRow = FindHighestRow();

        for (var i = 0; i < 1000; i++)
        {
            Map[highestRow + 2, i] = '#';
        }
    }

    private int FindHighestRow()
    {
        var highestRow = 0;

        for (var column = 0; column < 1000; column++)
        {
            for (var row = 0; row < 1000; row++)
            {
                if (Map[row, column] != '#')
                    continue;

                if (row <= highestRow)
                    continue;

                highestRow = row;
                break;
            }
        }

        return highestRow;
    }
}