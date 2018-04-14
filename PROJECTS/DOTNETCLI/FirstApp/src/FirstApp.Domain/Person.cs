using System;

namespace FirstApp.Domain
{
    public class Person
    {
        private static int _sequence = 0;

        public int Id { get; protected set; }
        public string Name { get; protected set; }
        public string Surname { get; protected set; }
        public string FullName { get; protected set;}

        protected Person() {}

        protected Person(string name, string surname)
        {
            Id = _sequence++;
            SetName(name);
            SetSurname(surname);
            SetFullName(Name, Surname);
        }


        public static Person Create(string name, string surname)
            => new Person(name, surname);


        public void SetName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new Exception($"{nameof(name)} cannot be empty");

            Name = name;
        }


        public void SetSurname(string surname)
        {
            if (string.IsNullOrWhiteSpace(surname))
                throw new Exception($"{nameof(surname)} cannot be empty");

            Surname = surname;
        }


        private void SetFullName(string name, string surname)
        {
            FullName = $"{name} {surname}";
        }
    }
}