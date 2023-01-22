namespace Ex_008.Models;

public class Tree
{
    public byte Size { get; }
    public int Row { get; }
    public int Column { get; }

    public Tree(byte size, int row, int column)
    {
        Size = size;
        Row = row;
        Column = column;
    }
}