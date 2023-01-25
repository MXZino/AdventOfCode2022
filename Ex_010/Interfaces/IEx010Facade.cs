namespace Ex_010.Interfaces;

public interface IEx010Facade
{
    int GetSumOfSignalStrength(int[] cyclesToReturn);
    IEnumerable<char> ProduceImage();
}