using FirstApp.Domain;
using FirstApp.Infrastructure;

namespace FirstApp.Application
{
  public class PersonService
    {
        private PersonRepository _repository;

        public PersonService()
        {
            _repository = new PersonRepository();
        }


        public void Handle(PersonCreateDTO dto)
        {
            var person = Person.Create(dto.Name, dto.Surname);
            _repository.AddPerson(person);
        }
    }
}