using BOOKSTORE.DOMAIN.Models;
using BOOKSTORE.IOC.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOOKSTORE.IOC.Repositories
{
    public class BookRepository : Repository<Book>
    {
        public BookRepository(AppDbContext context) : base(context)
        {
        }

        public override Book GetById(int id)
        {
            var query = _context.Set<Book>().Where(e => e.Id == id);

            if (query.Any())
            {
                return query.First();
            }
            return null;
        }

        public override IEnumerable<Book> GetAll()
        {
            var query = _context.Set<Book>();
            return query.Any() ? query.ToList() : new List<Book>();
        }
    }
}
