using RestWithASPNETUdemy.Hypermedia.Utils;
using RestWithASPNETUdemy.Model;
using System.Collections.Generic;

namespace RestWithASPNETUdemy.Business
{
    public interface IBookBusiness
    {
        BookVO Create(BookVO book);

        PagedSearchVO<BookVO> FindWithPagedSearch(
         string name, string sortDirection, int pageSize, int page);

        BookVO FindByID(long id);

        List<BookVO> FindByTitle(string title);

        BookVO Update(BookVO book);
        void Delete(long id);

    }
}
