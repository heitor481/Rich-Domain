using System;
using System.Collections.Generic;
using PaymentContext.Shared.Entities;
using Flunt.Validations;

namespace PaymentContext.Domain.Entities
{
    public class Subscription : Entity
    {
        private List<Payment> _payments;
        
        public Subscription(DateTime? expireDate)
        {
            this.StartDate = DateTime.Now;
            this.LastUpdateDate = DateTime.Now;
            this.ExpireDate = expireDate;
            this.Active = true;
            _payments = new List<Payment>();
        }

        public DateTime StartDate { get; private set; }

        public DateTime LastUpdateDate { get; private set; }

        public DateTime? ExpireDate { get; private set; }

        public bool Active { get; private set; }

        public IReadOnlyCollection<Payment> Payments { get { return _payments.ToArray(); } }

        public void AddPayment(Payment payment)
        {
            AddNotifications(new Contract()
                .Requires()
                .IsGreaterThan(DateTime.Now, payment.PaidDate, "Subscription.Payments", "Baixa no pagamento")
            );

            _payments.Add(payment);
        }

        public void SetActive()
        {
            this.Active = true;
            this.LastUpdateDate = DateTime.Now;
        }

        public void Inactivate()
        {
            this.Active = false;
            this.LastUpdateDate = DateTime.Now;
        }
    }

}