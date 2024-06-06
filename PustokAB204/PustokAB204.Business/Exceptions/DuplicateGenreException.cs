namespace PustokAB204.Business.Exceptions;

public class DuplicateGenreException : Exception
{
    public DuplicateGenreException(string? message) : base(message)
    {
    }
}
