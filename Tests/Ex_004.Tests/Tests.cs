using Ex_004.Interfaces;
using Ex_004.Models;

namespace Ex_004.Tests;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void CreatePair_IfSectorsValid_ReturnTrue()
    {
        const string dataLine = "6-96,5-96";
        var pair = new Pair(dataLine);
        Assert.Multiple(() =>
        {
            Assert.That(pair.FirstElf.StartSector, Is.EqualTo(6));
            Assert.That(pair.FirstElf.EndSector, Is.EqualTo(96));
            Assert.That(pair.SecondElf.StartSector, Is.EqualTo(5));
            Assert.That(pair.SecondElf.EndSector, Is.EqualTo(96));
        });
    }

    [TestCase("6-96,5-96", true)]
    [TestCase("6-7,8-9", false)]
    [TestCase("45-65,5-44", false)]
    public void IsFullyContainsSectors_IfDataValid_ReturnExpectedValue(string dataLine, bool result)
    {
        var pair = new Pair(dataLine);
        Assert.That(pair.IsFullyContainsSectors(), Is.EqualTo(result));
    }

    [Test]
    public void CountFullyContainedSectors_Is1_ReturnTrue()
    {
        IEx004Facade facade = new Ex004Ex004Facade(@"./assets/test_data.txt");
        Assert.That(facade.CountFullyContainedSectors(), Is.EqualTo(1));
    }

    [TestCase("6-96,5-96", true)]
    [TestCase("6-7,8-9", false)]
    [TestCase("45-65,5-45", true)]
    public void HasOverlappingAssignment_IfDataValid_ReturnExpectedValue(string dataLine, bool result)
    {
        var pair = new Pair(dataLine);
        Assert.That(pair.HasOverlappingAssignment(), Is.EqualTo(result));
    }
    
    [Test]
    public void CountOverlappingAssignments_Is1_ReturnTrue()
    {
        IEx004Facade facade = new Ex004Ex004Facade(@"./assets/test_data.txt");
        Assert.That(facade.CountOverlappingAssignments(), Is.EqualTo(1));
    }
}