using FluentValidation;
using FluentValidation.Validators;
using PustokAB204.Business.DTOs.AuthorDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PustokAB204.Business.DTOs.AuthorDTOs
{
    public class AuthorCreateDTO
    {
        public string Name { get; set; }        

    }
}


public class AuthorCreateDTOValidator : AbstractValidator<AuthorCreateDTO>
{
    public AuthorCreateDTOValidator()
    {
        RuleFor(x => x.Name)
                        .NotEmpty().WithMessage("Name bos ola bilmez")
                        .NotNull().WithMessage("Name null ola bilmez")
                        .MaximumLength(50).WithMessage("max length 50den artiq ola bilmez!");
    }
}