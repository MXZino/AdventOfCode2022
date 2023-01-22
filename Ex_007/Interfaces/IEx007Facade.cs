using Directory = Ex_007.Models.Directory;

namespace Ex_007.Interfaces;

public interface IEx007Facade
{
    Directory RootDirectory { get; }
    long? GetSizeOfDirectoryToDelete();
}