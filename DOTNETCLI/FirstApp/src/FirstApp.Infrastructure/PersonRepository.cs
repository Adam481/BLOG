using System;
using System.Collections.Generic;
using FirstApp.Domain;

namespace FirstApp.Infrastructure
{
    public class PersonRepository
    {
        private static List<Person> _people = new List<Person>();

        public void AddPerson(Person person)
        {
            if (_people.Exists(x => x.Id == person.Id))
                throw new Exception($"{nameof(person)} with id: {person.Id} already exists");

            _people.Add(person);
        }
    }
}