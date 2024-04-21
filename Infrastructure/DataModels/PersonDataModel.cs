using DomainModel.Snapshots;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DataModels
{
    public class PersonDataModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public DateTime CreateDateTime { get; set; }
        public string CreateDateTimeInPersianFormat { get; set; }
        public AddressDataModel HomeAddress { get; set; }
        public AddressDataModel? WorkAddress { get; set; }

        //we merge all documents in one table
        public List<DocumentDataModel> Documents { get; set; } = new List<DocumentDataModel>();
    }
}
