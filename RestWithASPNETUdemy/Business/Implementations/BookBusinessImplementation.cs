using RestWithASPNETUdemy.Data.Converter.Implementation;
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

        private readonly BookConverter _converter;

        public BookBusinessImplementation(IRepository<Book> repository)
        {
            _repository = repository;
            _converter = new BookConverter();
        }

        //Method responsible for returning all people
        public List<BookVO> FindAll()
        {
            return _converter.Parse(_repository.FindAll());
        }


        //Method responsible for returning one person by ID
        public BookVO FindByID(long id)
        {
            return _converter.Parse(_repository.FindByID(id));
        }
        
        //Methoh responsible to create one person
        public BookVO Create(BookVO book)
        {
            var personEntity = _converter.Parse(book);
            personEntity = _repository.Create(personEntity);
            return _converter.Parse(personEntity);
        }
        
        //Method responsible for updating a person for updating one person
        public BookVO Update(BookVO book)
        {
            var personEntity = _converter.Parse(book);
            personEntity = _repository.Update(personEntity);
            return _converter.Parse(personEntity);
        }

        //Method responsible for deleting a person from an ID
        public void Delete(long id)
        {
            _repository.Delete(id);

        }
    }
}

