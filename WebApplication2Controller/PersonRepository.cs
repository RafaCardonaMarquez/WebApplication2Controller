using ClassLibrary;
using EntityFramework.Database;
using System;
using WebApplication2Controller.Controllers;


public class PersonRepository : IPersonRepository
{
    private readonly PersonDbContext _Context;

    public PersonRepository(PersonDbContext context)
    {
        _Context = context;
    }
    //Get SINGLE record.
    public PersonDto GetPerson(int Id)
    {
        var person = _Context.Persons.SingleOrDefault(p => p.Id == Id);
        if (person is null)
            return null;
        return new PersonDto { 
            Id = person.Id,
            Name = person.Name,
            City= person.City 
        };
    }
    //Get ALL records.
    async Task<IEnumerable<PersonDto>> IPersonRepository.GetPersons()
    {
        var persons = _Context.Persons.Select(p => new PersonDto { Id = p.Id, Name = p.Name, City = p.City });
        
        return persons;
    }
    public PersonDto AddPerson(PersonDto person)
    {
        var newEntity = new Person { Name = person.Name, City = person.City };
        _Context.Persons.Add(newEntity);
        _Context.SaveChanges();
        person.Id = newEntity.Id;
        return person;
    }

    public void UpdatePerson(PersonDto personToUpdate)
    {
        var person = _Context.Persons.Single(p => p.Id == personToUpdate.Id);
        person.City = person.City;
        person.Name = person.Name;
        _Context.SaveChanges();
    }

    public void RemovePerson(int personId)
    {
        var personToRemove = _Context.Persons.Single(p => p.Id == personId);
        _Context.Persons.Remove(personToRemove);
        _Context.SaveChanges();
    }

}

