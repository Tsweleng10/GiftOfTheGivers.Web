using GiftOfTheGivers.Web.Models;
using System.ComponentModel.DataAnnotations;

namespace GiftOfTheGivers.Tests
{
    public class UnitTests
    {
        // TEST 1: Ensure Donation Amount cannot be negative
        [Fact]
        public void Donation_NegativeAmount_ShouldFailValidation()
        {
            // Arrange
            var donation = new Donation
            {
                Amount = -50, // Invalid amount
                Currency = "ZAR",
                DonationDate = DateTime.Now
            };

            // Act
            var validationContext = new ValidationContext(donation);
            var validationResults = new List<ValidationResult>();
            bool isValid = Validator.TryValidateObject(donation, validationContext, validationResults, true);

            // Assert
            Assert.False(isValid); // The test passes if validation FAILS (returns false)
        }

        // TEST 2: Ensure Donation Amount greater than 0 is valid
        [Fact]
        public void Donation_ValidAmount_ShouldPassValidation()
        {
            // Arrange
            var donation = new Donation
            {
                Amount = 100.50m,
                Currency = "ZAR",
                DonationDate = DateTime.Now
            };

            // Act
            var validationContext = new ValidationContext(donation);
            var validationResults = new List<ValidationResult>();
            bool isValid = Validator.TryValidateObject(donation, validationContext, validationResults, true);

            // Assert
            Assert.True(isValid);
        }

        // TEST 3: Ensure Volunteer Email must be valid
        [Fact]
        public void Volunteer_InvalidEmail_ShouldFailValidation()
        {
            // Arrange
            var volunteer = new VolunteerInterest
            {
                FullName = "Fortune Tester",
                Email = "not-an-email", // Invalid email format
                Phone = "0821234567",
                SubmittedAt = DateTime.Now
            };

            // Act
            var validationContext = new ValidationContext(volunteer);
            var validationResults = new List<ValidationResult>();
            bool isValid = Validator.TryValidateObject(volunteer, validationContext, validationResults, true);

            // Assert
            Assert.False(isValid);
        }
    }
}