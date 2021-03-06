using Flunt.Validations;
using PaymentContext.Domain.Enums;
using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects
{
    public class Email : ValueObject
    {
        public Email(string address)
        {
            this.Address = address;

            AddNotifications(new Contract()
                .Requires()
                .IsEmail(address, "Email.Adrress", "Email invaldio")
            );
        }

        public string Address { get; private set; }
    }
}