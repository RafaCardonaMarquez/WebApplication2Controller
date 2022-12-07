using ClassLibrary;

namespace WebApplication2Controller.Controllers
{
    public interface IPersonRepository
    {
        public PersonDto GetPerson(int personId);
        Task <IEnumerable<PersonDto>> GetPersons();
        public PersonDto AddPerson(PersonDto person);
        void RemovePerson(int personId);
        void UpdatePerson(PersonDto personToUpdate);
    }
}