using System;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Domain.Entities 
{
    public abstract class Payment 
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