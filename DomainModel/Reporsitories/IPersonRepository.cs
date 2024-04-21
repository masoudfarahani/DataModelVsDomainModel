using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Reporsitories
{
    public interface IPersonRepository
    {
        void Add(Person person);
        Task<Person> GetByIdAsync(Guid id);
    }
}
