using FluentValidation;
using Microsoft.AspNetCore.Http;
using PustokAB204.Core.Models;

namespace PustokAB204.Business.DTOs.BookDTOs;

public class BookCreateDTO
{
    public string Name { get; set; } = null!;
    public decimal Price { get; set; }
    public decimal CostPrice { get; set; }
    public decimal DiscountPercent { get; set; }
    public string Description { get; set; } = null!;
    public IFormFile ImageFile { get; set; } = null!;
    public int GenreId { get; set; }
    public int AuthorId { get; set; } 
}

public class BookCreateDTOValidator : AbstractValidator<BookCreateDTO>
{
    public BookCreateDTOValidator()
    {
        RuleFor(x => x.Name)
                .NotEmpty().WithMessage("name bosh ola bilmez!")
                .NotNull().WithMessage("name null ola bilmez!")
                .MaximumLength(100).WithMessage("max uzunluq 100 ola biler!");

        RuleFor(x => x.Description)
                 .NotEmpty().WithMessage("desc bosh ola bilmez!")
                .NotNull().WithMessage("desc null ola bilmez!")
                .MaximumLength(200).WithMessage("max uzunluq 200 ola biler!");

        RuleFor(x => x).Custom((x, context) =>
        {
            if (x.CostPrice > x.Price)
            {
                context.AddFailure("Price", "maya qiymeti satish qiymetinden baha ola bilmez!");
            }
        });
    }
}
