using Ex_001.Models;

namespace Ex_001.Interfaces;

public interface IDataAccess
{
    IEnumerable<Elf> ReadElves();
}