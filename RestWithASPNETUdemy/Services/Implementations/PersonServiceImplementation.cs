using RestWithASPNETUdemy.Model;
using RestWithASPNETUdemy.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace RestWithASPNETUdemy.Services.Implementations
{
    public class PersonServiceImplementation : IPersonService
    {

       
        private MySQLContext _context;

       public PersonServiceImplementation(MySQLContext context)
        {
            _context = context;
        }


        //Method responsible for returning all people,
        //againd thid information is mocks
        public List<Person> FindAll()
        {
            return _context.Persons.ToList();
        }


        //Method responsible for returning a person
        //as we have not acessed any database we are returning a mock
        public Person FindByID(long id)
        {
            return _context.Persons.SingleOrDefault(p => p.Id == id);
        } 
        
        public Person Create(Person person)
        {
            try
            {
                _context.Add(person);
                _context.SaveChanges();

            }
            catch (Exception){

                throw;
            }
            return person;
        }
        
        //Method responsible for updating a person for
        //being mock we return the same information passed
        public Person Update(Person person)
        {
            if (!Exists(person.Id)) return new Person();

            var result = _context.Persons.SingleOrDefault(p => p.Id.Equals(person.Id));
            if(result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(person);
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }

            }
          
            return person;
        }

        //Method responsible for deleting a person from an ID
        public void Delete(long id)
        {
            var result = _context.Persons.SingleOrDefault(p => p.Id.Equals(id));
            if(result != null)
            {
                try
                {
                    _context.Persons.Remove(result);
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }

        }

        private bool Exists(long id)
        {
            return _context.Persons.Any(p => p.Id.Equals(id));
        }
    }
}

