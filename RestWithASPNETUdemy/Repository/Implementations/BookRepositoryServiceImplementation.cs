using RestWithASPNETUdemy.Model;
using RestWithASPNETUdemy.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace RestWithASPNETUdemy.Repository.Implementations
{
    public class BookRepositoryImplementation : IBookRepository
    {
 
        private MySQLContext _context;

       public BookRepositoryImplementation(MySQLContext context)
        {
            _context = context;
        }

        //Method responsible for returning all people
        public List<Book> FindAll()
        {
            return _context.Books.ToList();
        }

        //Method responsible for returning one person by ID
        public Book FindByID(long id)
        {
            return _context.Books.SingleOrDefault(p => p.Id == id);
        }

        //Methoh responsible to create one person
        public Book Create(Book book)
        {
            _context.Add(book);
            _context.SaveChanges();

            return book;
        }

        //Method responsible for updating a person for updating one person
        public Book Update(Book book)
        {
            //We check if the person exists in the database
            //If it doesn't exist we return an empty person instace
            if (!Exists(book.Id)) return null;

            //Get the current status of the record in the database
            var result = _context.Books.SingleOrDefault(p => p.Id.Equals(book.Id));

            if (result != null)
            {
                // set changes and save
                _context.Entry(result).CurrentValues.SetValues(book);
                _context.SaveChanges();

            }

            return book;
        }

        //Method responsible for deleting a person from an ID
        public void Delete(long id)
        {
            var result = _context.Books.SingleOrDefault(p => p.Id.Equals(id));
            if(result != null)
            {
                _context.Books.Remove(result);
                _context.SaveChanges();
            }
        }

        public bool Exists(long id)
        {
            return _context.Books.Any(p => p.Id.Equals(id));
        }
    }
}

