using Common.Models;
using Ex_006.Interfaces;

namespace Ex_006;

public class Ex006Facade : IEx006Facade
{
    private readonly string _message;
    
    public Ex006Facade(string filePath)
    {
        _message = FileDataAccess
            .ReadFile(filePath)
            .First()
            .Trim();
    }

    public int GetBeginPacketPosition()
    {
        for (var i = 0; i < _message.Length - 3; i++)
        {
            if (_message.Substring(i, 4).Distinct().Count() == 4)
                return i + 4;
        }

        throw new ArgumentException();
    }

    public int GetStartOfMessagePosition()
    {
        for (var i = 0; i < _message.Length - 13; i++)
        {
            if (_message.Substring(i, 14).Distinct().Count() == 14)
                return i + 14;
        }

        throw new ArgumentException();
    }
}