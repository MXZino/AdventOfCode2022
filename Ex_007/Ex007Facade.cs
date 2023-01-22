using Common.Models;
using Ex_007.Interfaces;
using Ex_007.Models;
using Directory = Ex_007.Models.Directory;
using File = Ex_007.Models.File;

namespace Ex_007;

public class Ex007Facade : IEx007Facade
{
    public Directory RootDirectory { get; private set; }
    private Directory _currentDirectory;
    
    public Ex007Facade(string filePath)
    {
        var dataLines = FileDataAccess.ReadFile(filePath);
        CreateStructure(dataLines);
    }

    public long? GetSizeOfDirectoryToDelete()
    {
        var freeSpace = 70000000 - RootDirectory.GetSize();
        var sizesOfDirectories = RootDirectory
            .GetSizesOfDirectories()
            .OrderBy(x => x)
            .ToList();

        foreach (var size in sizesOfDirectories.Where(size => freeSpace + size >= 30000000))
            return size;

        return null;
    }
    
    private void CreateStructure(IEnumerable<string> dataLines)
    {
        foreach(var dataLine in dataLines)
            ProcessDataLine(dataLine);
    }

    private void ProcessDataLine(string dataLine)
    {
        if (Conditions.IsMovingToMainDirectory(dataLine))
        {
            CreateRootDirectory();
            return;
        }

        if (Conditions.IsListingDirectory(dataLine))
        {
            return;
        }

        if (Conditions.IsDirectoryListed(dataLine))
        {
            CreateDirectory(dataLine);
            return;
        }

        if (Conditions.IsMoveUp(dataLine))
        {
            MoveUp();
            return;
        }

        if (Conditions.IsGoIntoDirectory(dataLine))
        {
            GoIntoDirectory(dataLine);
            return;
        }

        CreateFile(dataLine);
    }

    private void CreateFile(string dataLine)
    {
        var chunks = dataLine.Split(" ");
        var file = new File(chunks[1], int.Parse(chunks[0]));
        _currentDirectory.AddFile(file);
    }

    private void GoIntoDirectory(string dataLine)
    {
        var chunks = dataLine.Split(" ");
        _currentDirectory = _currentDirectory.Directories.First(x => x.Name == chunks[2]);
    }

    private void MoveUp() => _currentDirectory = _currentDirectory.ParentDirectory;

    private void CreateDirectory(string dataLine)
    {
        var chunks = dataLine.Split(" ");

        var newDirectory = new Directory(_currentDirectory, chunks[1]);

        _currentDirectory.AddDirectory(newDirectory);
    }

    private void CreateRootDirectory()
    {
        RootDirectory = new Directory(null, "root");
        _currentDirectory = RootDirectory;
    }
}