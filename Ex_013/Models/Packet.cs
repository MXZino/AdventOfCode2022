using Ex_013.Interfaces;

namespace Ex_013.Models;

public class Packet : IPacket
{
    public int Value { get; }

    public Packet(string stringValue, PacketGroup parent)
    {
        Value = int.Parse(stringValue);
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

    public bool? CompareGroup(PacketGroup packetGroup)
    {
        var wrappedPacket = new PacketGroup
        {
            Packets = {this}
        };

        return wrappedPacket.Compare(packetGroup);
    }

    public bool? ComparePacket(Packet packet)
    {
        return packet.Value == Value ? null : packet.Value > Value;
    }
}