using PaymentContext.Domain.Enums;
using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects
{
    public class Document : ValueObject
    {
        public Document(string number, EdocumentType type)
        {
            this.Number = number;
            this.Type = type;
        }

        public string Number { get; private set; }

        public EdocumentType Type { get; private set; }
    }
}