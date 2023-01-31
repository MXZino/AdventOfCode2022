namespace Ex_012.Models;

public class Field
{
    public Field[] AvailableFields { get; set; }
    public int Row { get; set; }
    public int Column { get; set; }
    public char Value { get; set; }
    public bool Inspected { get; set; }
    public int CostOfWay { get; set; } = 100000;
    public Field PreviousField { get; set; }

    public void SetAvailableFields(Field[] allFields, int rows, int columns)
    {
        var neighbours = FindNeighbours(allFields, rows, columns).ToArray();

        switch (Value)
        {
            case 'S':
                AvailableFields = neighbours.Where(x => x.Value == 'a').ToArray();
                return;
            case 'E':
                AvailableFields = null;
                return;
            case 'z':
                AvailableFields = neighbours.Where(x => x.Value == Value || x.Value == 'E').ToArray();
                return;
            default:
                AvailableFields = neighbours.Where(x => x.Value != 'E' && x.Value != 'S' && x.Value <= Value + 1)
                    .ToArray();
                return;
        }
    }

    private IEnumerable<Field> FindNeighbours(Field[] allFields, int rows, int columns)
    {
        if (Row != 0)
            yield return GetTopNeighbour(allFields);

        if (Column != 0)
            yield return GetLeftNeighbour(allFields);

        if (Row != rows - 1)
            yield return GetBottomNeighbour(allFields);

        if (Column != columns - 1)
            yield return GetRightNeighbour(allFields);
    }

    private Field GetRightNeighbour(IEnumerable<Field> allFields) =>
        allFields.First(x => x.Row == Row && x.Column == Column + 1);

    private Field GetBottomNeighbour(IEnumerable<Field> allFields) =>
        allFields.First(x => x.Row == Row + 1 && x.Column == Column);

    private Field GetLeftNeighbour(IEnumerable<Field> allFields) =>
        allFields.First(x => x.Row == Row && x.Column == Column - 1);

    private Field GetTopNeighbour(IEnumerable<Field> allFields) =>
        allFields.First(x => x.Row == Row - 1 && x.Column == Column);

    public void Reset()
    {
        Inspected = false;
        CostOfWay = 100000;
        PreviousField = null;
    }
}