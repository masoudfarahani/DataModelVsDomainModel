using DomainModel;
using FluentAssertions;
using Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Test
{
    public class PersistTests : TestBase
    {
        [Fact]
        public async Task write_person_in_db_correctly()
        {

            //arrange
            var personRepository = new PersonRepository(this._context);
            var actualPerson = CreatePerson();

            //act
            personRepository.Add(actualPerson);
            await this._context.SaveChangesAsync();
            this.DetachAllEntities();

            //assert
            var persistedPerson = await personRepository.GetByIdAsync(actualPerson.Id);
            persistedPerson.Should().Be(actualPerson);
        }


        [Fact]
        public async Task update_persisted_person_correctly()
        {
            //arrange
            var personRepository = new PersonRepository(this._context);
            var actualPerson = CreatePerson();
            personRepository.Add(actualPerson);
            await this._context.SaveChangesAsync();
            //you can comment this line and get person from change tracker
            this.DetachAllEntities();


            //act
            actualPerson.ReSetAgeTo(40);
            actualPerson.HomeAddress.ReSetStreetTo("new street name");
            actualPerson.HomeAddress.ReSetNumberTo(13);
            actualPerson.EducationalDocuments = new List<Document>();
            await personRepository.UpdateAsync(actualPerson);
            await this._context.SaveChangesAsync();



            //assert
            var persistedPerson = await personRepository.GetByIdAsync(actualPerson.Id);
            persistedPerson.Should().Be(actualPerson);
        }

        private Person CreatePerson()
        {
            var person = new Person("John doee", 30, new Address("street name", 1));

            person.WorkAddress = new Address("work address street name", 10);

            person.EducationalDocuments.Add(new Document("education documenturl",DateTime.Now.AddYears(1)));
            person.IdentityDocuments.Add(new Document("identity documenturl",DateTime.Now.AddYears(1)));

            return person;

        }
    }
}