using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects
{
    public class Name : ValueObject
    {
        public Name(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;

            if (string.IsNullOrEmpty(firstName))
            {
                AddNotification("firstname", "É necessário colocar o primeiro nome");
            }
        }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }
    }
}