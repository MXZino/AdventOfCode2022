namespace Common.Interfaces;

public interface IDataAccess
{
    IEnumerable<string> ReadFile(string path);
}