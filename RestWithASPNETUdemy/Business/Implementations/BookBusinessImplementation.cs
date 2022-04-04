using RestWithASPNETUdemy.Data.Converter.Implementation;
using RestWithASPNETUdemy.Hypermedia.Utils;
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

        private IBookRepository _repository;

        private readonly BookConverter _converter;

        public BookBusinessImplementation(IBookRepository repository)
        {
            _repository = repository;
            _converter = new BookConverter();
        }

        //Method responsible for returning all book with pagination 
        public PagedSearchVO<BookVO> FindWithPagedSearch(
            string name, string sortDirection, int pageSize, int page)
        {
          
            var sort = (!string.IsNullOrEmpty(sortDirection)) && !sortDirection.Equals("desc") ? "asc" : "desc";
            var size = (pageSize < 1) ? 10 : pageSize;
            var offset = page > 0 ? (page - 1) * size : 0;

            string query = @"select * from books p where 1 = 1 ";
            if (!string.IsNullOrEmpty(name)) query = query + $" and p.title like '%{name}%' ";
            query += $" order by p.title {sort} limit {size} offset {offset}";

            string countQuery = @"select count(*) from books p where 1 = 1 ";
            if (!string.IsNullOrEmpty(name)) countQuery = countQuery + $" and p.title like '%{name}%' ";

            var books = _repository.FindWithPagedSearch(query);
            int totalResults = _repository.GetCount(countQuery);

            return new PagedSearchVO<BookVO>
            {
                CurrentPage = page,
                List = _converter.Parse(books),
                PageSize = size,
                SortDirections = sort,
                TotalResults = totalResults

            };
        }

        //Method responsible for returning one person by ID
        public BookVO FindByID(long id)
        {
            return _converter.Parse(_repository.FindByID(id));
        }

        //Method responsible for returning book by title
        public List<BookVO> FindByTitle(string title)
        {
            return _converter.Parse(_repository.FindByTitle(title));
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

