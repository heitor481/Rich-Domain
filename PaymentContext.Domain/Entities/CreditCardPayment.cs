using System;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Domain.Entities 
{
    public class CreditCardPayment : Payment
    {
        public CreditCardPayment(string cardHolderName, string cardNumber, string lastTransactionNumber,
        DateTime paidDate, 
        DateTime expireDate, 
        decimal total, 
        Document document, 
        string payer, 
        decimal totalPayment, 
        Address addres, 
        Email email) : base(paidDate, expireDate, total, document, payer, totalPayment, addres, email)
        {
            this.CardHolderName = cardHolderName;
            this.CardNumber = cardNumber;
            this.LastTransactionNumber = lastTransactionNumber;
        }

        public string CardHolderName { get; private set; }

        public string CardNumber { get; private set; }

        public string LastTransactionNumber { get; private set; }
    }
}