using RestWithASPNETUdemy.Model;
using RestWithASPNETUdemy.Model.Context;
using RestWithASPNETUdemy.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace RestWithASPNETUdemy.Business.Implementations
{
    public class BookBusinessImplementation : IBookBusiness
    {

        private IRepository<Book> _repository;

       public BookBusinessImplementation(IRepository<Book> repository)
        {
            _repository = repository;
        }


        //Method responsible for returning all people
        public List<Book> FindAll()
        {
            return _repository.FindAll();
        }


        //Method responsible for returning one person by ID
        public Book FindByID(long id)
        {
            return _repository.FindByID(id);
        }
        
        //Methoh responsible to create one person
        public Book Create(Book book)
        {
           return _repository.Create(book);
        }
        
        //Method responsible for updating a person for updating one person
        public Book Update(Book book)
        {
           return _repository.Update(book);
        }

        //Method responsible for deleting a person from an ID
        public void Delete(long id)
        {
            _repository.Delete(id);

        }
    }
}

