using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests
{
    [TestClass]
    public class DocumentsTests
    { 
        [TestMethod]
        public void ShouldReturnErrorWhenCNPJIsInvalid()
        {
            Document document = new Document("12345", EdocumentType.CNPJ);
            Assert.IsTrue(document.Invalid);
        }

        [TestMethod]
        public void ShouldReturnSuccessWhenCNPJIsValid()
        {
            Document document = new Document("19920587000185", EdocumentType.CNPJ);
            Assert.IsTrue(document.Valid);
        }

        [TestMethod]
        public void ShouldReturnErrorWhenCPFIsInvalid()
        {
            Document document = new Document("123", EdocumentType.CPF);
            Assert.IsTrue(document.Invalid);
        }

        [TestMethod]
        public void ShouldReturnSuccessWhenCPFIsValid()
        {
            Document document = new Document("34612916093", EdocumentType.CPF);
            Assert.IsTrue(document.Valid);
        }
    }
}
