using DAL_CRUD.Interface;
using DAL_CRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL_CRUD.Service
{
    public class PersonService
    {
        private readonly IRepository<Person> _person;

        public PersonService(IRepository<Person> repository)
        {
            _person = repository;
        }
        public IEnumerable<Person> GetPersonByUserId(string userId)
        {
            return _person.GetAll().Where(x => x.UserEmail == userId).ToList();
        }
        public IEnumerable<Person> GetAllPersons()
        {
            try
            {
                return _person.GetAll().ToList();
            }
            catch
            {
                throw;
            }
        }
        public Person GetPersonByUsername(string Username)
        {
            return _person.GetAll().Where(x => x.UserEmail == Username).FirstOrDefault();
        }
        public async Task<Person> AddPerson(Person person)
        {
            return await _person.Create(person);
        }
        public bool DeletePerson(string UserEmail)
        {
            try
            {
                var datalist = _person.GetAll().Where(x => x.UserEmail == UserEmail).ToList();
                foreach(var item in datalist)
                {
                    _person.Delete(item);
                }
                return true;
            }
            catch(Exception e)
            {
                return true;
            }

        }
        public bool UpdatePerson(Person person)
        {
            try
            {
                var datalist = _person.GetAll().Where(x => x.IsDeleted != true).ToList();
                foreach(var item in datalist)
                {
                    _person.Update(item);
                }
                return true;
            }
            catch(Exception e)
            {
                return true;
            }
        }
    }
}
