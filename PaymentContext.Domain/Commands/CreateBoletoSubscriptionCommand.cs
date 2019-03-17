using System;
using Flunt.Notifications;
using Flunt.Validations;
using PaymentContext.Domain.Enums;

namespace PaymentContext.Domain.Commands
{
    public class CreateBoletoSubscriptionCommand : Notifiable
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Document { get; set; }

        public string Email { get; set; }

        public string BarCode { get; set; }

        public string BoletoNumber { get; set; }

        public string PaymentNNumber { get; set; }

        public DateTime PaidDate { get; set; }

        public DateTime ExpireDate { get; set; }

        public decimal Total { get; set; }

        public string PayerDocument { get; set; }

        public EdocumentType PayerDocumentType { get; set; }

        public string Payer { get; set; }

        public decimal TotalPayment { get; set; }

         public string PayerEmail { get; set; }

        public string Street { get;  set; }

        public int Number { get;  set; }

        public string Neighborhood { get;  set; }

        public string City { get;  set; }

        public string State { get;  set; }

        public string Country { get;  set; }

        public string Zip { get;  set; }

        public void Validate() {
            AddNotifications(new Contract()
                .Requires()
                .HasMinLen(this.FirstName, 3, "Name.FirstName", "Nome deve conter três caracters")
                .HasMinLen(this.LastName, 3, "Name.LastName", "Sobrenome deve conter três caracters")
                .HasMaxLen(this.FirstName, 40, "Name.FirstName", "Sobrenome deve conter três caracters")
            );
        }
    }
}