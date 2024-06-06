namespace PustokAB204.Core.Models;

public class Book : BaseEntity
{
    public string Name { get; set; } = null!;
    public decimal Price { get; set; }
    public decimal CostPrice { get; set; }
    public decimal DiscountPercent { get; set; }
    public string Description { get; set; } = null!;
    public string ImageUrl { get; set; } = null!;

    public int GenreId { get; set; }
    public Genre Genre { get; set; }
    public List<Tag> Tags { get; set; }
    public int AuthorId { get; set; }
    public Author Author { get; set; }      

}
