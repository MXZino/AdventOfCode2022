namespace Ex_007.Models;

public static class Conditions
{
    public static bool IsMovingToMainDirectory(string dataLine) 
        => dataLine.Trim() == @"$ cd /";

    public static bool IsListingDirectory(string dataLine)
        => dataLine.Trim() == "$ ls";

    public static bool IsDirectoryListed(string dataLine) 
        => dataLine.StartsWith("dir");

    public static bool IsMoveUp(string dataLine)
        => dataLine.StartsWith("$ cd ..");

    public static bool IsGoIntoDirectory(string dataLine)
        => dataLine.StartsWith("$ cd");
}