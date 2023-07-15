namespace Newme.Purchase.Domain.Models.ValueObjects
{
    public record Address
    {
        private Address() {}
        public Address(string zipCode, string street, int number, string complement, string neighborhood, string city, string state)
        {
            ZipCode = zipCode;
            Street = street;
            Number = number;
            Complement = complement;
            Neighborhood = neighborhood;
            City = city;
            UF = state;
        }

        public string ZipCode { get; private set; }
        public string Street { get; private set; }
        public int Number { get; private set; }
        public string Complement { get; private set; }
        public string Neighborhood { get; private set; }
        public string City { get; private set; }
        public string UF { get; private set; }
    }
}