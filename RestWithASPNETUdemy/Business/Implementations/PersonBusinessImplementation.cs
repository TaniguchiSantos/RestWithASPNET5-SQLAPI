using RestWithASPNETUdemy.Data.Converter.Implementation;
using RestWithASPNETUdemy.Data.VO;
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
      
        private IRepository<Person> _repository;

        private readonly PersonConverter _converter;

       public PersonBusinessImplementation(IRepository<Person> repository)
        {
            _repository = repository;
            _converter = new PersonConverter();
        }


        //Method responsible for returning all people
        public List<PersonVO> FindAll()
        {
            return _converter.Parse(_repository.FindAll());
        }


        //Method responsible for returning one person by ID
        public PersonVO FindByID(long id)
        {
            return _converter.Parse(_repository.FindByID(id));
        }
        
        //Methoh responsible to create one person
        public PersonVO Create(PersonVO person)
        {
            var personEntity = _converter.Parse(person);
            personEntity = _repository.Create(personEntity);
            return _converter.Parse(personEntity);
        }
        
        //Method responsible for updating a person for updating one person
        public PersonVO Update(PersonVO person)
        {
            var personEntity = _converter.Parse(person);
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

