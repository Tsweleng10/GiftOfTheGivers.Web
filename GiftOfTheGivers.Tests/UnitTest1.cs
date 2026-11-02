using GiftOfTheGivers.Web.Models;
using System.ComponentModel.DataAnnotations;

namespace GiftOfTheGivers.Tests
{
    public class UnitTests
    {
        [Fact]
        public void Donation_NegativeAmount_ShouldFailValidation()
        {
            var donation = new Donation { Amount = -50, Currency = "ZAR", DonationDate = DateTime.Now };
            var validationContext = new ValidationContext(donation);
            var validationResults = new List<ValidationResult>();
            bool isValid = Validator.TryValidateObject(donation, validationContext, validationResults, true);
            Assert.False(isValid);
        }

        [Fact]
        public void Donation_ValidAmount_ShouldPassValidation()
        {
            var donation = new Donation { Amount = 100.50m, Currency = "ZAR", DonationDate = DateTime.Now };
            var validationContext = new ValidationContext(donation);
            var validationResults = new List<ValidationResult>();
            bool isValid = Validator.TryValidateObject(donation, validationContext, validationResults, true);
            Assert.True(isValid);
        }
    }
}