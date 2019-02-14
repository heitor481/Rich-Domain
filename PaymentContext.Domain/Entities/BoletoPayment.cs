using System;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Domain.Entities 
{
    public class BoletoPayment : Payment
    {
        public BoletoPayment(string barCode, 
        string boletoNumber, 
        DateTime paidDate, 
        DateTime expireDate, 
        decimal total, 
        Document document, 
        string payer, 
        decimal totalPayment, 
        Address addres, 
        Email email):base(paidDate, expireDate, total, document, payer, totalPayment, addres, email)
        {
            this.BarCode = barCode;
            this.BoletoNumber = boletoNumber;
        }

        public string BarCode { get; private set; }

        public string BoletoNumber { get; private set; }
    }
    
}