namespace PustokAB204.Core.Models;

public class Tag : BaseEntity
{
    public string Name { get; set; }
    public List<Book> Books { get; set; }
}
