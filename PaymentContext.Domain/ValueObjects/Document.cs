using PaymentContext.Domain.Enums;
using PaymentContext.Shared.ValueObjects;
using Flunt.Validations;

namespace PaymentContext.Domain.ValueObjects
{
    public class Document : ValueObject
    {
        public Document(string number, EdocumentType type)
        {
            this.Number = number;
            this.Type = type;

            AddNotifications(new Contract()
                .Requires()
                .IsTrue(Validate(), "Document.Number", "Documento inválido")
            );
        }

        public string Number { get; private set; }

        public EdocumentType Type { get; private set; }

        private bool Validate()
        {
            if(this.Type == EdocumentType.CNPJ && this.Number.Length == 14) { return true; }

            if(this.Type == EdocumentType.CPF && this.Number.Length == 11) { return true; }

            return false;
        }
    }
}