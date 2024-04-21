using AutoMapper;
using DomainModel;
using DomainModel.Reporsitories;
using Infrastructure.DataModels;
using Infrastructure.Mappers;
using Microsoft.EntityFrameworkCore;
using System.Security.Principal;

namespace Infrastructure.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly Context _context;

        private static readonly Mapper _mapper = new Mapper(new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<PersonDataModel, PersonDataModel>()
            .ForMember(c => c.CreateDateTime, d => d.Ignore())
            .ForMember(c => c.CreateDateTimeInPersianFormat, d => d.Ignore());
            cfg.CreateMap<AddressDataModel, AddressDataModel>();
        }));

        public PersonRepository(Context context)
        {
            _context = context;

        }

        public void Add(Person person)
        {
            var personsnapshot = person.GetSnapShot();

            var personDataModel = personsnapshot.ToDataModel();

            _context.Persons.Add(personDataModel);

        }

        public async Task UpdateAsync(Person person)
        {
            var personsnapshot = person.GetSnapShot();

            var personDataModel = personsnapshot.ToDataModel();
            var trackedPerson = await _context.FindAsync<PersonDataModel>(person.Id);

            _mapper.Map(personDataModel, trackedPerson);
        }


        public async Task<Person> GetByIdAsync(Guid id)
        {
            var personDataModel = await _context.Persons.SingleOrDefaultAsync(c => c.Id == id);

            if (personDataModel == null)
                throw new Exception("person not found");//or do whatever you want

            var snapshot = personDataModel.ToSnapshot();

            return Person.CreateFrom(snapshot);
        }
    }
}
