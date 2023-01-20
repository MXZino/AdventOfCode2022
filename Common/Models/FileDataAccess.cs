namespace Common.Models;

public class FileDataAccess
{
    public static IEnumerable<string> ReadFile(string path) => File.ReadLines(path);
}