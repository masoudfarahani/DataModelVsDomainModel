using DomainModel.Snapshots;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.IO;
using Microsoft.VisualBasic;

namespace DomainModel
{
    public class Person
    {
        private const int MINIMUM_ACCEPTABLE_AGE = 18;
        //used for restore data from snapshot
        private Person() { }

        public Person(string name, int age, Address homeAddress)
        {
            Id = Guid.NewGuid();
            Name = name;
            Age = age;
            HomeAddress = homeAddress;
        }


        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public int Age { get; private set; }

        public List<Document> EducationalDocuments { get; set; }=new List<Document>();

        public List<Document> IdentityDocuments { get; set; } = new List<Document>();


        public void ReSetAgeTo(int age)
        {
            if (age < MINIMUM_ACCEPTABLE_AGE)
                throw new Exception("invalid Age");
            Age = age;
        }


        /// required
        public Address HomeAddress { get; private set; }

        /// optional
        public Address? WorkAddress { get; set; }

        public PersonSnapShot GetSnapShot()
        {
            return new PersonSnapShot
            {
                Id = Id,
                Name = Name,
                Age = Age,
                HomeAddress = HomeAddress.GetSnapshot(),
                WorkAddress = WorkAddress?.GetSnapshot(),
                EducationalDocuments=this.EducationalDocuments.Select(c=>c.GetSnapshot()).ToList(),
                IdentityDocuments =this.IdentityDocuments.Select(c=>c.GetSnapshot()).ToList()
            };
        }

        public static Person CreateFrom(PersonSnapShot snapShot)
        {
            return new Person
            {
                Id = snapShot.Id,
                Name = snapShot.Name,
                Age = snapShot.Age,
                HomeAddress = Address.CreateFrom(snapShot.HomeAddress),
                WorkAddress = snapShot.WorkAddress != null ? Address.CreateFrom(snapShot.WorkAddress) : null,
                EducationalDocuments=snapShot.EducationalDocuments.Select(Document.CreateFrom).ToList(),
                IdentityDocuments   = snapShot.IdentityDocuments.Select(Document.CreateFrom).ToList()
            };

        }

        public override bool Equals(object? obj)
        {
            return obj is Person other
                && other.Name == Name
                && other.Age == Age
                && other.HomeAddress.Equals(HomeAddress)
                && other.EducationalDocuments.All(this.EducationalDocuments.Contains) && other.EducationalDocuments.Count() == this.EducationalDocuments.Count()
                && other.IdentityDocuments.All(this.IdentityDocuments.Contains) && other.IdentityDocuments.Count() == this.IdentityDocuments.Count();
        }
    }
}
