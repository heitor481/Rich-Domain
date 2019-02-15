using Flunt.Validations;
using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects
{
    public class Name : ValueObject
    {
        public Name(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;

            AddNotifications(new Contract()
                .Requires()
                .HasMinLen(this.FirstName, 3, "Name.FirstName", "Nome deve conter três caracters")
                .HasMinLen(this.LastName, 3, "Name.LastName", "Nome deve conter três caracters")
            );
        }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }
    }
}