using FinalProject.Models;
using System.Collections.Generic;

namespace FinalProject.DataDB
{
    public interface IPersonData
    {
        List<Person> GetPeople();

        Person AddPerson(Person person);
        Person GetPerson(string FullName);

        Person UpdatePerson(Person person);

        void DeletePerson(Person person);


    }
}
