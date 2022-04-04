using RestWithASPNETUdemy.Model;
using RestWithASPNETUdemy.Model.Context;
using RestWithASPNETUdemy.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RestWithASPNETUdemy.Repository
{
    public class BookRepository : GenericRepository<Book>, IBookRepository
    {

        public BookRepository(MySQLContext context) : base (context) { }

        public Book Disable(long id)
        {
            //If doesn't have a person with that id then return null
            if (!_context.Books.Any(p => p.Id.Equals(id))) return null;
            var book = _context.Books.SingleOrDefault(p => p.Id.Equals(id));
            if(book != null){
                book.Enabled = false;
                try
                {
                    _context.Entry(book).CurrentValues.SetValues(book);
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return book;
        }

        public List<Book> FindByTitle(string title)
        {
          return _context.Books.Where(
          p => p.Title.Contains(title)).ToList();
            
        }      
    }
}
