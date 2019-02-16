using PaymentContext.Domain.Enums;
using PaymentContext.Shared.ValueObjects;
using Flunt.Validations;

namespace PaymentContext.Domain.ValueObjects
{
    public class Address : ValueObject
    {
        public Address(string street, int number, string neighborhood, string city, string state, string country, string zip)
        {
            this.Number = number;
            this.Street = street;
            this.Neighborhood = neighborhood;
            this.City = city;
            this.State = state;
            this.Country = country;
            this.Zip = zip;

            AddNotifications(new Contract()
                .Requires()
                .HasMinLen(this.Street, 3, "Address.Street", "A rua precisa ter 3 caracteres")
                .HasMinLen(this.City, 3, "Address.City", "A cidade precisa de 3 caracteres")
                .HasMinLen(this.State, 3, "Address.State", "O estado precisa de 3 caracteres")
            );
        }

        public string Street { get; private set; }

        public int Number { get; private set; }

        public string Neighborhood { get; private set; }

        public string City { get; private set; }

        public string State { get; private set; }

        public string Country { get; private set; }

        public string Zip { get; private set; }
        
    }
}