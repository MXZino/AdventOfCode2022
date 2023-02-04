using Ex_013.Interfaces;

namespace Ex_013.Models;

public class PacketGroup : IPacket, IComparable<PacketGroup>
{
    public List<IPacket> Packets { get; } = new();
    public bool IsDividerPacket { get; }

    public PacketGroup()
    {
    }

    public PacketGroup(ref string dataLine, bool isDividerPacket = false)
    {
        IsDividerPacket = isDividerPacket;
        
        dataLine = dataLine[1..];

        while (!string.IsNullOrWhiteSpace(dataLine))
        {
            switch (dataLine.First())
            {
                case '[':
                    Packets.Add(new PacketGroup(ref dataLine));
                    break;

                case ']':
                    dataLine = dataLine[1..];
                    return;

                default:
                    AddPacket(ref dataLine);
                    break;
            }
        }
    }

    private void AddPacket(ref string dataLine)
    {
        var commaOrEndBracketIndex = dataLine.IndexOfAny(new[] {',', ']'});

        var value = dataLine[..commaOrEndBracketIndex];

        if (!string.IsNullOrWhiteSpace(value))
            Packets.Add(new Packet(value, this));

        dataLine = dataLine.ElementAt(commaOrEndBracketIndex) == ','
            ? dataLine[(commaOrEndBracketIndex + 1)..]
            : dataLine[commaOrEndBracketIndex..];
    }

    public bool? Compare(IPacket packetToCompare)
    {
        return packetToCompare switch
        {
            Packet packet => ComparePacket(packet),
            PacketGroup packetGroup => CompareGroup(packetGroup),
            _ => throw new ArgumentOutOfRangeException(nameof(packetToCompare), packetToCompare, null)
        };
    }


    public bool? CompareGroup(PacketGroup groupToCompare)
    {
        var groupToComparePacketSize = groupToCompare.Packets.Count;

        for (var i = 0; i < Packets.Count; i++)
        {
            if (i == groupToComparePacketSize)
                return false;

            var rightOrder = Packets.ElementAt(i).Compare(groupToCompare.Packets.ElementAt(i));
            if (rightOrder != null)
                return rightOrder;
        }

        if (Packets.Count < groupToComparePacketSize)
            return true;

        return null;
    }

    public bool? ComparePacket(Packet packetToCompare)
    {
        var wrappedPacket = new PacketGroup
        {
            Packets = {packetToCompare}
        };

        return CompareGroup(wrappedPacket);
    }

    public static bool operator <(PacketGroup first, PacketGroup second)
    {
        var comparer = new PacketGroupComparer();

        return comparer.Compare(first, second) != 1;
    }
    
    public static bool operator >(PacketGroup first, PacketGroup second)
    {
        var comparer = new PacketGroupComparer();

        return comparer.Compare(first, second) == 1;
    }

    public int CompareTo(PacketGroup other)
    {
        var comparer = new PacketGroupComparer();
        return comparer.Compare(this, other);
    }
}