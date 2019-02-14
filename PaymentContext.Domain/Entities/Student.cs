using System.Collections.Generic;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.Entities;

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
            foreach (var subs in this.Subscriptions)
            {
                subs.Inactivate();
            }

            _subscription.Add(subscription);
        }
    }

}