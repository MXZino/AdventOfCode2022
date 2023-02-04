using Ex_013.Models;

namespace Ex_013.Interfaces;

public interface IPacket
{
    bool? Compare(IPacket packetToCompare);
}