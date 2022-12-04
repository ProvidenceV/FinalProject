using FinalProject.Models;
using System.Collections.Generic;
using System.Linq;

namespace FinalProject.DataDB
{
    public class SQLPersonData : IPersonData
    {
        private CoreDbContext _personContext;
        public SQLPersonData(CoreDbContext personContext)
        {
            _personContext = personContext;
        }
        public Person AddPerson(Person person)
        {
            person.FullName = person.FullName;
            _personContext.People.Add(person);
            _personContext.SaveChanges();
            return person;
        }

        public void DeletePerson(Person person)
        {

            _personContext.People.Remove(person);
            _personContext.SaveChanges();

        }

        public List<Person> GetPeople()
        {
            return _personContext.People.ToList();
        }

        public Person GetPerson(string fullName)
        {
            var person = _personContext.People.Find(fullName);
            return person;
        }

        public Person UpdatePerson(Person person)
        {
            var existingPerson = _personContext.People.Find(person.FullName);
            if (existingPerson != null)
            {
                _personContext.People.Update(person);
                _personContext.SaveChanges();
            }
            return person;
        }
    }
}
