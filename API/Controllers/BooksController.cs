using System.Collections.Generic;
using System.Threading.Tasks;
using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class BooksController : BaseApiController
    {
        private readonly IBookRepository _bookRepo;
        private readonly IMapper _mapper;

        public BooksController(IBookRepository bookRepo, IMapper mapper)
        {
            _bookRepo = bookRepo;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BookToReturnDto>> GetBook(int id)
        {
            var book = await _bookRepo.GetBookWithAuthor(id);

            if (book == null)
            {
                return NotFound();
            }

            return _mapper.Map<Book, BookToReturnDto>(book);
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<BookToReturnDto>>> GetBooks()
        {
            var books = await _bookRepo.GetBooksWithAuthors();

            var data = _mapper.Map<IReadOnlyList<Book>, IReadOnlyList<BookToReturnDto>>(books);

            return Ok(data);
        }
    }
}