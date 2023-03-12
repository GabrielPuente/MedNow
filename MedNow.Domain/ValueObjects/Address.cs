namespace MedNow.Domain.ValueObjects
{
    public class Address
    {
        public Guid UserId { get; private set; }

        public string ZipCode { get; private set; }

        public string Street { get; private set; }

        public int Number { get; private set; }

        public string Neighborhood { get; private set; }

        public string City { get; private set; }

        public string State { get; private set; }

        public Address(string zipCode, string street, int number, string neighborhood, string city, string state)
        {
            ZipCode = zipCode;
            Street = street;
            Number = number;
            Neighborhood = neighborhood;
            City = city;
            State = state;
        }

        public void SetUserId(Guid userId)
        {
            UserId = userId;
        }
    }
}
