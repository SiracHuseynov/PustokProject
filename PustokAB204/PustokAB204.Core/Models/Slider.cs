using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PustokAB204.Core.Models;

public class Slider : BaseEntity
{
    [Required]
    [StringLength(100)]
    public string Title { get; set; }
    [Required]
    [StringLength(150)]
    public string Description { get; set; }
    public string? RedirectUrl { get; set; }

    [StringLength(100)]
    public string? ImageUrl { get; set; }
    [NotMapped]
    public IFormFile? ImageFile { get; set; }
}
