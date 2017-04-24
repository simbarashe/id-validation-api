using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StandardBank.IdValidation.Core.Entities;

namespace StandardBank.IdValidation.Services.Tests
{
    [TestClass]
    public class IdentificationServiceTests
    {
        private IdentificationService _identificationService;

        [TestInitialize]
        public void Initialize()
        {
            _identificationService = new IdentificationService();
        }

        [TestMethod]
        public void Given_AValidId_WhenValidating_Then_AllIdentificationPropertiesShouldBePopulated()
        {
            //Arrange
            const string id = "8502076289187";
            string validationMessage;
            var expectedIdentification = new Identification
            {
                Identifier = id,
                Citizenship = "Permanet Resident",
                DateOfBirth= new DateTime(1985,2,7),
                Gender="Male"
            };

            //Act
            var actualIdentification = _identificationService.Validate(id, out validationMessage);

            //Assert
            Assert.IsNotNull(actualIdentification);
            Assert.AreEqual(string.Empty, validationMessage);
            Assert.AreEqual(expectedIdentification.Identifier, actualIdentification.Identifier);
            Assert.AreEqual(expectedIdentification.Gender, actualIdentification.Gender);
            Assert.AreEqual(expectedIdentification.Citizenship, actualIdentification.Citizenship);
            Assert.AreEqual(expectedIdentification.DateOfBirth, actualIdentification.DateOfBirth);
        }

        [TestMethod]
        public void Given_AnIdWith10Digits_WhenValidating_Then_AValidationMessageShouldBeSet()
        {
            //Arrange
            const string id = "8509076289";
            string validationMessage;
            var expectedIdentification = new Identification();
            const string expectedValidationMessage = "The supplied id (8509076289) is invalid ";

            //Act
            var actualIdentification = _identificationService.Validate(id, out validationMessage);

            //Assert
            Assert.IsNotNull(actualIdentification);
            Assert.AreEqual(expectedValidationMessage , validationMessage);
            Assert.IsNull(actualIdentification.Identifier);
            Assert.IsNull(actualIdentification.Gender);
            Assert.IsNull(actualIdentification.Citizenship);
            Assert.AreEqual(DateTime.MinValue, actualIdentification.DateOfBirth);
        }

        [TestMethod]
        public void Given_AnIdWith14Digits_WhenValidating_Then_AValidationMessageShouldBeSet()
        {
            //Arrange
            const string id = "85090762891879";
            string validationMessage;
            var expectedIdentification = new Identification();
            const string expectedValidationMessage = "The supplied id (85090762891879) is invalid ";

            //Act
            var actualIdentification = _identificationService.Validate(id, out validationMessage);

            //Assert
            Assert.IsNotNull(actualIdentification);
            Assert.AreEqual(expectedValidationMessage, validationMessage);
            Assert.IsNull(actualIdentification.Identifier);
            Assert.IsNull(actualIdentification.Gender);
            Assert.IsNull(actualIdentification.Citizenship);
            Assert.AreEqual(DateTime.MinValue, actualIdentification.DateOfBirth);
        }
    }
}
