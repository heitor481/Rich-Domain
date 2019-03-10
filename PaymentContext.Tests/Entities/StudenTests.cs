using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests
{
    [TestClass]
    public class StudentTests
    {
        private readonly Student student;

        private readonly Name name;

        private readonly Address address;

        private readonly Document doc;

        private readonly Email email;

        private readonly Subscription subscription;


        public StudentTests()
        {
            this.name = new Name("Heitor", "Ribeiro");
            this.doc = new Document("34612916093", EdocumentType.CPF);
            this.email = new Email("heitor_481@hotmail.com");
            this.address = new Address("Rua gaspar", 209, "Residencial", "Mairinque", "São Paulo", "Brazil", "18120000");
            this.student = new Student(name, doc, email);
            this.subscription = new Subscription(null);
        }


        [TestMethod]
        public void ShouldReturnErrorWhenHadActiveSubscription()
        {
            PaypalPayment paypalPayment = new PaypalPayment("12345678", DateTime.Now, DateTime.Now.AddDays(5),
            250, this.doc, "Heitor", 250, this.address, this.email);
            this.subscription.AddPayment(paypalPayment);
            this.student.AddSubscriptions(this.subscription);
            this.student.AddSubscriptions(this.subscription);
            Assert.IsTrue(student.Invalid);
        }

        // [TestMethod]
        // public void ShouldReturnErrorWhenSubscriptionHasNoPayment()
        // {
        //     this.student.AddSubscriptions(this.subscription);
        //     Assert.IsTrue(this.student.Invalid);
        // }

        // [TestMethod]
        // public void ShouldReturnSuccessWhenHadActiveSubscription()
        // {
        //     PaypalPayment paypalPayment = new PaypalPayment("12345678", DateTime.Now, DateTime.Now.AddDays(5),
        //     250, this.doc, "Heitor", 250, this.address, this.email);
        //     this.subscription.AddPayment(paypalPayment);
        //     this.student.AddSubscriptions(this.subscription);
        //     Assert.IsTrue(student.Valid);
        // }
    }
}
