using Ex_002.Models;

namespace Ex_002.Interfaces;

public interface IDataAccess
{
    Tuple<Player, Player> ReadDataAsMoves();
}