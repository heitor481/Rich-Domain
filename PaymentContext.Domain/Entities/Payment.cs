using System;
using Flunt.Validations;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.Entities;

namespace PaymentContext.Domain.Entities 
{
    public abstract class Payment : Entity
    {
        protected Payment(DateTime paidDate, DateTime expireDate, decimal total, Document document, string payer, decimal totalPayment, Address addres, Email email)
        {
            Number = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 10).ToUpper();
            PaidDate = paidDate;
            ExpireDate = expireDate;
            Total = total;
            Document = document;
            Payer = payer;
            TotalPayment = totalPayment;
            Addres = addres;
            Email = email;

            AddNotifications(new Contract() 
                .Requires()
                .IsLowerOrEqualsThan(0, this.Total, "Payment.Total", "O total não pode ser zero")
                .IsGreaterOrEqualsThan(Total, this.TotalPayment, "Payment.TotalPayment", "O valor pago é menor que o valor do boleto")
            );
            
        }

        public string Number { get; private set; }

        public DateTime PaidDate { get; private set; }

        public DateTime ExpireDate { get; private set; }

        public decimal Total { get; private set; }

        public Document Document { get; private set; }

        public string Payer { get; private set; }

        public decimal TotalPayment { get; private set; }

        public Address Addres { get; private set; }

        public Email Email { get; private set; }
    }

}