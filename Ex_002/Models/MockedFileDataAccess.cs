namespace Ex_002.Models;

public class MockedFileDataAccess : DataAccessBase
{
    protected override string FilePath => @"./assets/test_data.txt";
}