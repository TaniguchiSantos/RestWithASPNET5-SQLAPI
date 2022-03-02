using Microsoft.EntityFrameworkCore;
using RestWithASPNETUdemy.Model.Base;
using RestWithASPNETUdemy.Model.Context;
using System.Collections.Generic;
using System.Linq;

namespace RestWithASPNETUdemy.Repository.Generic
{
    public class GenericRepository<T> : IRepository<T> where T : BaseEntity
    {

        private MySQLContext _context;

        private DbSet<T> dataset;

        public GenericRepository(MySQLContext context)
        {
            _context = context;
            dataset = _context.Set<T>();
        }

        public T Create(T item)
        {

            dataset.Add(item);
            _context.SaveChanges();

            return item;    
        }

        public void Delete(long id)
        {
            var result = dataset.SingleOrDefault(p => p.Id.Equals(id));

            dataset.Remove(result);
            _context.SaveChanges();
        }

        public bool Exists(long id)
        {
            throw new System.NotImplementedException();
        }

        public List<T> FindAll()
        {
            return dataset.ToList();
        }

        public T FindByID(long id)
        {
            return dataset.SingleOrDefault(p => p.Id.Equals(id));
        }

        public T Update(T item)
        {
            //We check if the person exists in the database
            //If it doesn't exist we return an empty person instace
            if (!Exists(item.Id)) return null;

            //Get the current status of the record in the database
            var result = dataset.SingleOrDefault(p => p.Id.Equals(item.Id));

            if (result != null)
            {
                // set changes and save
                _context.Entry(result).CurrentValues.SetValues(item);
                _context.SaveChanges();              
            }

            return item;
        }
    }
}
