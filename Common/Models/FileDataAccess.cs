namespace Common.Models;

public static class FileDataAccess
{
    public static IEnumerable<string> ReadFile(string path) => File.ReadLines(path);
}