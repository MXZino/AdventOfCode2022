using Common.Models;
using Ex_013.Interfaces;
using Ex_013.Models;

namespace Ex_013;

public class Ex013Facade : IEx013Facade
{
    private readonly Pair[] _pairs;

    public Ex013Facade(string filePath)
    {
        var dataLines = FileDataAccess.ReadFile(filePath).Where(x => !string.IsNullOrWhiteSpace(x)).ToArray();

        var groups = GroupData(dataLines);

        _pairs = groups.Select(x => new Pair(x)).ToArray();
    }

    private static IEnumerable<string[]> GroupData(IReadOnlyList<string> dataLines)
    {
        for (var i = 0; i < dataLines.Count / 2; i++)
        {
            yield return new[]
            {
                dataLines[i * 2],
                dataLines[i * 2 + 1]
            };
        }
    }

    public int SumOfIndicesOfOrderedPairs()
    {
        var sum = 0;

        for (var i = 0; i < _pairs.Length; i++)
        {
            if (_pairs[i].IsRightOrder)
                sum += i + 1;
        }

        return sum;
    }

    public int GetDecoderKey()
    {
        var packetGroups = _pairs
            .Select(x => x.FirstGroup)
            .Concat(_pairs
                .Select(x => x.SecondGroup))
            .ToList();

        var dividerPackets = new[] {"[[2]]", "[[6]]"};
        
        packetGroups.Add(new PacketGroup(ref dividerPackets[0], true));
        packetGroups.Add(new PacketGroup(ref dividerPackets[1], true));

        var orderedPackets = packetGroups.OrderDescending().ToList();

        var decoderKey = 1;

        for (var i = 0; i < orderedPackets.Count; i++)
        {
            if (orderedPackets[i].IsDividerPacket)
                decoderKey *= i + 1;
        }

        return decoderKey;
    }
}