using System;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Domain.Entities
{
    public class PaypalPayment : Payment
    {
        public PaypalPayment(string transactionCode,
        DateTime paidDate,
        DateTime expireDate,
        decimal total,
        Document document,
        string payer,
        decimal totalPayment,
        Address addres,
        Email email) : base(paidDate, expireDate, total, document, payer, totalPayment, addres, email)
        {
            this.TransactionCode = transactionCode;
        }

        public string TransactionCode { get; private set; }
    }

}