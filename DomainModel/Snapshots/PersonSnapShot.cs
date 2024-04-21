using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Snapshots
{

    //it's not domain model.it used just for transfering date betwin domain model and data model and it's structure depend on your viow point
    public class PersonSnapShot
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = "";
        public int Age { get; set; }

        public AddressSnapshot HomeAddress { get; set; }
        public AddressSnapshot? WorkAddress { get; set; }

        public List<DocumentSnapshot> EducationalDocuments { get; set; }

        public List<DocumentSnapshot> IdentityDocuments { get; set; }
    }
}
