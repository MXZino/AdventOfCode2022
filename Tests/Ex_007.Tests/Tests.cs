using Ex_007.Interfaces;

namespace Ex_007.Tests;

public class Tests
{

    private IEx007Facade _facade;
    
    [SetUp]
    public void Setup()
    {
        _facade = new Ex007Facade(@"./assets/007_test_data.txt");
    }

    [Test]
    public void CheckStructure_IsCorrect_ReturnTrue()
    {
        var rootDirectory = _facade.RootDirectory;
        Assert.Multiple(() =>
        {
            Assert.That(rootDirectory.Directories.Any(x => x.Name == "a"), Is.True);
            Assert.That(rootDirectory.Directories.Any(x => x.Name == "d"), Is.True);
            Assert.That(rootDirectory.Files.Any(x => x.Name == "b.txt"), Is.True);
            Assert.That(rootDirectory.Files.Any(x => x.Name == "c.dat"), Is.True);
        });
        var aDir = rootDirectory.Directories.First(x => x.Name == "a");
        Assert.Multiple(() =>
        {
            Assert.That(aDir.Directories.Any(x => x.Name == "e"), Is.True);
            Assert.That(aDir.Files.Any(x => x.Name == "f"), Is.True);
            Assert.That(aDir.Files.Any(x => x.Name == "g"), Is.True);
            Assert.That(aDir.Files.Any(x => x.Name == "h.lst"), Is.True);

            Assert.That(aDir.Files.First(x => x.Name == "h.lst").Size, Is.EqualTo(62596));
        });
        var eDir = aDir.Directories.First(x => x.Name == "e");
        
        Assert.That(eDir.Files.Any(x=> x.Name == "i"), Is.True);
        
        var dDir = rootDirectory.Directories.First(x => x.Name == "d");
        Assert.Multiple(() =>
        {
            Assert.That(dDir.Files.Any(x => x.Name == "j"), Is.True);
            Assert.That(dDir.Files.Any(x => x.Name == "d.log"), Is.True);
            Assert.That(dDir.Files.Any(x => x.Name == "d.ext"), Is.True);
            Assert.That(dDir.Files.Any(x => x.Name == "k"), Is.True);
        });
    }

    [Test]
    public void GetSize_Is48381165_ReturnTrue()
    {
        var rootDirectory = _facade.RootDirectory;
        Assert.That(rootDirectory.GetSize(), Is.EqualTo(48381165));
    }

    [Test]
    public void GetSizeWithDirectoriesSizeAtMost100000_Is95437_ReturnTrue()
    {
        var rootDirectory = _facade.RootDirectory;
        Assert.That(rootDirectory.GetSize(100000), Is.EqualTo(95437));
    }
    
    [Test]
    public void GetSizeOfDirectoryToDelete_Is24933642_ReturnTrue()
    {
        Assert.That(_facade.GetSizeOfDirectoryToDelete(), Is.EqualTo(24933642));
    }
}