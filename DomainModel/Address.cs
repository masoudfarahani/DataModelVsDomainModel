using DomainModel.Snapshots;

namespace DomainModel
{
    public class Address
    {
        //used for restore data from snapshot
        private Address() { }

        public Address(string street, int number)
        {
            Street = street;
            Number = number;
        }

        public string Street { get; private set; }
        public int Number { get; private set; }


        public void ReSetStreetTo(string street)
        {
            if (string.IsNullOrEmpty(street))
                throw new Exception("invalid street name");

            Street = street;
        }


        public void ReSetNumberTo(int number)
        {
            if (number < 0)
                throw new Exception("invalid number");

            Number = number;
        }


        internal static Address CreateFrom(AddressSnapshot homeAddress)
        {
            return new Address
            {
                Street = homeAddress.Street,
                Number = homeAddress.Number
            };
        }

        internal AddressSnapshot GetSnapshot()
        {
            return new AddressSnapshot
            {
                Street = Street,
                Number = Number
            };
        }

        public override bool Equals(object? obj)
        {
            return obj is Address other
                && other.Street == Street
                && other.Number == Number;
        }
    }
}
