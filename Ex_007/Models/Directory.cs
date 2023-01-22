namespace Ex_007.Models;

public class Directory
{
    public Directory ParentDirectory { get; }
    public string Name { get; }
    public List<Directory> Directories { get; }
    public List<File> Files { get; }

    public Directory(Directory parentDirectory, string name)
    {
        ParentDirectory = parentDirectory;
        Directories = new List<Directory>();
        Files = new List<File>();
        Name = name;
    }

    public void AddDirectory(Directory directory)
    {
        Directories.Add(directory);
    }

    public void AddFile(File file)
    {
        Files.Add(file);
    }

    public long GetSize() => 
        Directories.Sum(directory => directory.GetSize()) + Files.Sum(file => file.Size);

    public long GetSize(long dirMaxSize)
    {
        var currentDirSize = GetSize();
        var totalSizeAtMostDirMaxSize = Directories.Sum(directory => directory.GetSize(dirMaxSize));

        if (currentDirSize <= dirMaxSize)
            totalSizeAtMostDirMaxSize += currentDirSize;

        return totalSizeAtMostDirMaxSize;
    }

    public IEnumerable<long> GetSizesOfDirectories()
    {
        var sizes = new List<long>();

        foreach (var directory in Directories)
            sizes.AddRange(directory.GetSizesOfDirectories());

        sizes.Add(GetSize());

        return sizes;
    }
}