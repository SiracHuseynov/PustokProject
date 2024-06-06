namespace PustokAB204.Business.Exceptions;

public class FileNotFoundException : Exception
{
    public FileNotFoundException(string? message) : base(message)
    {
    }
}
