using PustokAB204.Business.DTOs.AuthorDTOs;
using PustokAB204.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PustokAB204.Business.Services.Abstracts
{
    public interface IAuthorService
    {
        Task AddAsync(AuthorCreateDTO authorCreateDTO);
        void Delete(int id);
        void Update(AuthorUpdateDTO authorUpdateDTO);

        AuthorGetDTO Get(Func<Author, bool>? func = null);
        IEnumerable<AuthorGetDTO> GetAll(Func<Author, bool>? func = null);



    }
}
