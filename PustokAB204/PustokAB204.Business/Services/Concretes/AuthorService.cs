using AutoMapper;
using PustokAB204.Business.DTOs.AuthorDTOs;
using PustokAB204.Business.DTOs.BookDTOs;
using PustokAB204.Business.Exceptions;
using PustokAB204.Business.Services.Abstracts;
using PustokAB204.Core.Models;
using PustokAB204.Core.RepositoryAbstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace PustokAB204.Business.Services.Concretes
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IMapper _mapper;

        public AuthorService(IAuthorRepository authorRepository, IMapper mapper)
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
        }

        public async Task AddAsync(AuthorCreateDTO authorCreateDTO)
        {
            if (authorCreateDTO == null)
                throw new EntityNotFoundException("Author tapilmadi!");

            Author author = _mapper.Map<Author>(authorCreateDTO);

            await _authorRepository.AddAsync(author);
            await _authorRepository.CommitAsync();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public AuthorGetDTO Get(Func<Author, bool>? func = null)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<AuthorGetDTO> GetAll(Func<Author, bool>? func = null)
        {
            var authors =_authorRepository.GetAll(func); 

            IEnumerable<AuthorGetDTO> authorsDto = _mapper.Map<IEnumerable<AuthorGetDTO>>(authors);

            return authorsDto;
        }

        public void Update(AuthorUpdateDTO authorUpdateDTO)
        {
            throw new NotImplementedException();
        }
    }
}
