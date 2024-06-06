using PustokAB204.Core.Models;

namespace PustokAB204.Business.DTOs.BookDTOs;

public class BookGetDTO
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public decimal Price { get; set; }
    public decimal CostPrice { get; set; }

    public decimal DiscountPercent { get; set; }
    public string Description { get; set; } = null!;
    public string ImageUrl { get; set; } = null!;
    public Genre Genre { get; set; } 
    public Author Author { get; set; } 

}
