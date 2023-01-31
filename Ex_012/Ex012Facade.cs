using System.Diagnostics;
using Common.Models;
using Ex_012.Interfaces;
using Ex_012.Models;

namespace Ex_012;

public class Ex012Facade : IEx012Facade
{
    private readonly Field[] _fields;
    private int _columns;
    private int _rows;

    public Ex012Facade(string filePath)
    {
        var dataLines = FileDataAccess.ReadFile(filePath);
        _fields = InitializeFields(dataLines).ToArray();
        InitializeAvailableFields();
    }

    public void FindShortestWay()
    {
        var startingField = _fields.First(x => x.Value == 'S');
        FindShortestWay(startingField);
    }

    private void FindShortestWay(Field startingField)
    {
        startingField.CostOfWay = 0;

        while (_fields.Any(x => !x.Inspected))
        {
            var inspectedField = _fields.Where(x => !x.Inspected).OrderBy(x => x.CostOfWay).First();
            inspectedField.Inspected = true;

            if (inspectedField.Value == 'E')
                continue;

            foreach (var neighbour in inspectedField.AvailableFields.Where(x => !x.Inspected))
            {
                if (neighbour.CostOfWay > inspectedField.CostOfWay + 1)
                {
                    neighbour.CostOfWay = inspectedField.CostOfWay + 1;
                    neighbour.PreviousField = inspectedField;
                }
            }
        }
    }

    public int GetSteps() => _fields.First(x => x.Value == 'E').CostOfWay;

    public int GetStepsFromA()
    {
        Parallel.ForEach(_fields, field =>
        {
            field.Reset();
        });

        var aFields = _fields.Where(x => x.Value == 'a').ToArray();
        
        return aFields.Select(GetStepsFromA).Min();
    }

    private int GetStepsFromA(Field startingField)
    {
        
        Parallel.ForEach(_fields, field =>
        {
            field.Reset();
        });
        
        FindShortestWay(startingField);
        return GetSteps();
    }

    private IEnumerable<Field> InitializeFields(IEnumerable<string> dataLines)
    {
        var dataLinesArray = dataLines.ToArray();
        _rows = dataLinesArray.Length;

        for (var i = 0; i < _rows; i++)
        {
            var fields = InitializeField(dataLinesArray[i], i).ToArray();

            foreach (var field in fields)
                yield return field;
        }
    }

    private IEnumerable<Field> InitializeField(string dataLine, int rowIndex)
    {
        var chars = dataLine.ToArray();
        _columns = chars.Length;

        for (var i = 0; i < _columns; i++)
        {
            yield return new Field
            {
                Column = i,
                Row = rowIndex,
                Value = chars[i]
            };
        }
    }

    private void InitializeAvailableFields() =>
        Parallel.ForEach(_fields, field => { field.SetAvailableFields(_fields, _rows, _columns); });
}