using Common.Models;
using Ex_015.Interfaces;
using Ex_015.Models;

namespace Ex_015;

public class Ex015Facade : IEx015Facade
{
    private readonly Sensor[] _sensors;

    public Ex015Facade(string filePath)
    {
        var dataLines = FileDataAccess.ReadFile(filePath);
        _sensors = dataLines.Select(x => new Sensor(x)).ToArray();
    }

    public int GetPositionsWithoutBeacon(int y)
    {
        var intervals = _sensors
            .Select(x => x.GetInterval(y))
            .Where(x => x != null)
            .OrderBy(x => x.Item1)
            .ThenBy(x => x.Item2)
            .ToArray();

        var beaconsOnY = _sensors
            .Select(x => x.ClosestBeaconPosition)
            .Where(x => x.Y == y)
            .Select(x => x.X)
            .Distinct()
            .ToArray();

        int? startX = null;

        var distances = intervals.Select(x => GetDistance(x, ref startX, beaconsOnY)).ToArray();

        return distances.Sum();
    }

    private int GetDistance(Tuple<int, int> intervals, ref int? startX, int[] beaconsXPositions)
    {
        if (startX is null)
        {
            startX = intervals.Item2 + 1;
            return GetFirstDistance(intervals, beaconsXPositions);
        }
        
        if (beaconsXPositions.Contains(startX.Value))
            startX++;

        var distance = (startX > intervals.Item1
            ? intervals.Item2 - startX.Value
            : intervals.Item2 - intervals.Item1) + 1;

        if (startX == intervals.Item1)
            distance--;

        if (distance < 0)
            return 0;

        var startPosition = startX >= intervals.Item1 ? startX.Value : intervals.Item1;

        var beaconsInInterval = beaconsXPositions.Count(x => x >= startPosition && x <= intervals.Item2);

        if (startX < intervals.Item2)
            startX = intervals.Item2 + 1;

        return distance - beaconsInInterval;
    }

    private static int GetFirstDistance(Tuple<int, int> intervals, IEnumerable<int> beaconsXPositions)
    {
        var distance = intervals.Item2 - intervals.Item1 + 1;
        var beaconsInInterval = beaconsXPositions.Count(x => x >= intervals.Item1 && x <= intervals.Item2);
        return distance - beaconsInInterval;
    }
}