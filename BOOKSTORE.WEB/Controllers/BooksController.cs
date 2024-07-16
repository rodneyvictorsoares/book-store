using BOOKSTORE.DOMAIN.Interfaces;
using BOOKSTORE.DOMAIN.Models;
using BOOKSTORE.WEB.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BOOKSTORE.WEB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly BookService _bookservice;
        private readonly IRepository<Book> _bookRepository;

        public BooksController(BookService bookservice, IRepository<Book> bookRepository)
        {
            _bookservice = bookservice;
            _bookRepository = bookRepository;
        }

        [HttpGet]
        public IEnumerable<BookDTO> GetBooks()
        {
            var books = _bookRepository.GetAll();

            var resut = books.Select(c => new BookDTO { Id = c.Id, Titulo = c.Titulo, Genero = c.Genero, Autor = c.Autor, AnoPublicacao = c.AnoPublicacao });
            return resut;
        }

        [HttpGet("{id}")]
        public ActionResult<Book> GetBook(int id)
        {
            var book = _bookRepository.GetById(id);

            if (book == null)
                return NotFound(new { message = $"Livro id = {id}, não encontrado." });

            return Ok(book);

        }
    }
}
