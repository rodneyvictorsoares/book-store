using BOOKSTORE.DOMAIN.Interfaces;

namespace BOOKSTORE.DOMAIN.Models
{
    public class BookService
    {
        private readonly IRepository<Book> _bookRepository;

        public BookService(IRepository<Book> bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public void Create(int id, string titulo, string genero, string autor, int anoPublicacao)
        {
            var book = _bookRepository.GetById(id);

            if (book == null)
            {
                book = new Book(titulo, genero, autor, anoPublicacao);
                _bookRepository.Save(book);
            }
            else
            {
                book.Update(titulo, genero, autor, anoPublicacao);
            }
        }
    }
}
