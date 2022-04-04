using RestWithASPNETUdemy.Data.VO;
using RestWithASPNETUdemy.Model;
using System.Collections.Generic;

namespace RestWithASPNETUdemy.Repository
{
    public interface IBookRepository : IRepository<Book>
    {
        Book Disable(long id);

        List<Book> FindByTitle(string title);
  
    }
}
