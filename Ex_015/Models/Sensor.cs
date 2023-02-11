using System.Drawing;

namespace Ex_015.Models;

public class Sensor
{
    public Point SensorPosition { get; }
    public Point ClosestBeaconPosition { get; }

    public Sensor(string dataLine)
    {
        var chunks = dataLine.Split(',');

        SensorPosition = new Point
        {
            X = GetValue(chunks[0]),
            Y = GetSensorY(chunks[1])
        };

        ClosestBeaconPosition = new Point
        {
            X = GetValue(chunks[1]),
            Y = GetValue(chunks[2])
        };
    }

    private int GetValue(string data)
    {
        var equalSignIndex = data.LastIndexOf('=');
        return int.Parse(data[(equalSignIndex + 1)..]);
    }

    private int GetSensorY(string data)
    {
        var equalSignIndex = data.IndexOf('=');
        var endOfValueIndex = data.IndexOf(':');
        return int.Parse(data[(equalSignIndex + 1)..endOfValueIndex]);
    }

    private int GetMaxLength() =>
        Math.Abs(SensorPosition.X - ClosestBeaconPosition.X)
        + Math.Abs(SensorPosition.Y - ClosestBeaconPosition.Y);

    public Tuple<int, int> GetInterval(int y)
    {
        var maxLength = GetMaxLength();

        if (y < SensorPosition.Y - maxLength)
            return null;

        if (y > SensorPosition.Y + maxLength)
            return null;

        var distance = maxLength - Math.Abs(SensorPosition.Y - y);

        return new Tuple<int, int>(SensorPosition.X - distance, SensorPosition.X + distance);
    }
}