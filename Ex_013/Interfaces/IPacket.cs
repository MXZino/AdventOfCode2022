using Ex_013.Models;

namespace Ex_013.Interfaces;

public interface IPacket
{
    PacketGroup Parent { get; set; }
    bool? Compare(IPacket packetToCompare);
}