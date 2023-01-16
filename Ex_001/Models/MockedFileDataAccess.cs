namespace Ex_001.Models;

public class MockedFileDataAccess : DataAccessBase
{
    public override string FilePath => @"./assets/mocked_data.txt";
}