using CreditCardValidator.Controllers;
using CreditCardValidator.Models.Dto;
using CreditCardValidator.Services.Interface;
using CreditCardValidator.Tests.TestData;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;

namespace CreditCardValidator.Tests
{
    public class CreditCardControllerTests
    {
        private readonly Mock<ILogger<CreditCardController>> _loggerMock;
        private readonly Mock<ICreditCardService> _creditCardServiceMock;
        private readonly CreditCardController _controller;

        public CreditCardControllerTests()
        {
            _loggerMock = new Mock<ILogger<CreditCardController>>();
            _creditCardServiceMock = new Mock<ICreditCardService>();
            _controller = new CreditCardController(_loggerMock.Object, _creditCardServiceMock.Object);
        }

        [Fact]
        public void Validate_ShouldReturnOk_WhenCardNumberIsValid()
        {
            // Arrange
            string validCardNumber = CardNumberTestData.ValidCardNumber;
            var apiResponse = CardNumberTestData.ValidCardApiResponse();

            _creditCardServiceMock
                .Setup(s => s.ValidateCreditCardNumber(validCardNumber))
                .Returns(apiResponse);

            // Act
            var result = _controller.Validate(validCardNumber);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var response = Assert.IsType<APIResponse<string>>(okResult.Value);
            Assert.False(response.HasError);
            Assert.Equal(CardNumberTestData.ValidFormattedCardNumber, response.Data);
        }

        [Fact]
        public void Validate_ShouldReturnBadRequest_WhenCardNumberIsInvalid()
        {
            // Arrange
            string invalidCardNumber = CardNumberTestData.InvalidCardNumber;
            var apiResponse = CardNumberTestData.InvalidCardApiResponse();

            _creditCardServiceMock
                .Setup(s => s.ValidateCreditCardNumber(invalidCardNumber))
                .Returns(apiResponse);

            // Act
            var result = _controller.Validate(invalidCardNumber);

            // Assert
            var badRequestResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(400, badRequestResult.StatusCode);

            var response = Assert.IsType<APIResponse<string>>(badRequestResult.Value);
            Assert.True(response.HasError);
            Assert.Contains("Invalid card number.", response.Errors);
        }

        [Fact]
        public void Validate_ShouldReturnBadRequest_WhenCardNumberIsEmpty()
        {
            // Arrange
            string emptyCardNumber = CardNumberTestData.EmptyCardNumber;

            var apiResponse = CardNumberTestData.EmptyCardApiResponse();

            _creditCardServiceMock
                .Setup(s => s.ValidateCreditCardNumber(emptyCardNumber))
                .Returns(apiResponse);

            // Act
            var result = _controller.Validate(emptyCardNumber);

            // Assert
            var badRequestResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(400, badRequestResult.StatusCode);

            var response = Assert.IsType<APIResponse<string>>(badRequestResult.Value);
            Assert.True(response.HasError);
            Assert.Contains("Card number cannot be null or empty.", response.Errors);
        }

        [Fact]
        public void Validate_ShouldReturnBadRequest_WhenCardNumberContainsNonDigits()
        {
            // Arrange
            string invalidCardNumber = CardNumberTestData.CardNumberWithNonDigits;
            var apiResponse = CardNumberTestData.NonDigitsCardApiResponse();

            _creditCardServiceMock
                .Setup(s => s.ValidateCreditCardNumber(invalidCardNumber))
                .Returns(apiResponse);

            // Act
            var result = _controller.Validate(invalidCardNumber);

            // Assert
            var badRequestResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(400, badRequestResult.StatusCode);

            var response = Assert.IsType<APIResponse<string>>(badRequestResult.Value);
            Assert.True(response.HasError);
            Assert.Contains("Card number must contain only digits.", response.Errors);
        }
    }
}