using RestWithASPNETUdemy.Model;
using RestWithASPNETUdemy.Model.Context;
using RestWithASPNETUdemy.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace RestWithASPNETUdemy.Business.Implementations
{
    public class PersonBusinessImplementation : IPersonBusiness
    {

       
        private IPersonRepository _repository;

       public PersonBusinessImplementation(IPersonRepository repository)
        {
            _repository = repository;
        }


        //Method responsible for returning all people
        public List<Person> FindAll()
        {
            return _repository.FindAll();
        }


        //Method responsible for returning one person by ID
        public Person FindByID(long id)
        {
            return _repository.FindByID(id);
        }
        
        //Methoh responsible to create one person
        public Person Create(Person person)
        {
           return _repository.Create(person);
        }
        
        //Method responsible for updating a person for updating one person
        public Person Update(Person person)
        {
            //We check if the person exists in the database
            //If it doesn't exist we return an empty person instace
            if (!Exists(person.Id)) return new Person();

            //Get the current status of the record in the database
            var result = _repository.Persons.SingleOrDefault(p => p.Id.Equals(person.Id));
            if(result != null)
            {
                try
                {
                    // set changes and save
                    _repository.Entry(result).CurrentValues.SetValues(person);
                    _repository.SaveChanges();
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
            var result = _repository.Persons.SingleOrDefault(p => p.Id.Equals(id));
            if(result != null)
            {
                try
                {
                    _repository.Persons.Remove(result);
                    _repository.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }

        }

        private bool Exists(long id)
        {
            return _repository.Persons.Any(p => p.Id.Equals(id));
        }
    }
}

