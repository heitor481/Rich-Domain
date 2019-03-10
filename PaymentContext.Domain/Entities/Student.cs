using System.Collections.Generic;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.Entities;
using Flunt.Validations;

namespace PaymentContext.Domain.Entities
{
    public class Student : Entity
    {
        private List<Subscription> _subscription;

        public Student(Name name, Document document, Email email)
        {
            this.Name = name;
            this.Document = document;
            this.Email = email;
            _subscription = new List<Subscription>();

            AddNotifications(name, document, email);
        }

        public Name Name { get; set; }

        public Document Document { get; set; }

        public Email Email { get; private set; }

        public Address Addres { get; private set; }

        public IReadOnlyCollection<Subscription> Subscriptions { get { return _subscription.ToArray(); } }

        public void AddSubscriptions(Subscription subscription)
        {
            var hasSubscriptionActive = false;

            foreach (var sub in _subscription)
            {
                if(sub.Active) { hasSubscriptionActive = true; } 
            }

            AddNotifications(new Contract()
                .Requires()
                .IsFalse(hasSubscriptionActive, "Student.Subscriptions", "Você já tem uma assinatura activa")
                .AreEquals(0, subscription.Payments.Count, "Student.Subscription.Payments", "Deve ter uns pagamentos")
            );

            _subscription.Add(subscription);
        }
    }

}