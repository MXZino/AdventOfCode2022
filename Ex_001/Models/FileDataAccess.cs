namespace Ex_001.Models;

public class FileDataAccess : DataAccessBase
{
    protected override string FilePath => @"./assets/data.txt";
}