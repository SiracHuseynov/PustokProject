namespace PustokAB204.Business.Exceptions;

public class EntityNotFoundException : Exception
{
    public EntityNotFoundException(string? message) : base(message)
    {
    }
}
