using Common.Interfaces;

namespace Common.Models;

public class FileDataAccess : IDataAccess
{
    public IEnumerable<string> ReadFile(string path) => File.ReadLines(path);
}