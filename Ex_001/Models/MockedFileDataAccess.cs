namespace Ex_001.Models;

public class MockedFileDataAccess : DataAccessBase
{
    protected override string FilePath => @"./assets/mocked_data.txt";
}