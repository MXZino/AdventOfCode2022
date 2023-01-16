namespace Ex_002.Models;

public class FileDataAccess : DataAccessBase
{
    protected override string FilePath => @"./assets/data.txt";
}