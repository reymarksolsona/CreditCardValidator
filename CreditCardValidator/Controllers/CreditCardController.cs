using CreditCardValidator.Models.Dto;
using CreditCardValidator.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CreditCardValidator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreditCardController : ControllerBase
    {
        private readonly ILogger<CreditCardController> _logger;
        private readonly ICreditCardService _creditCardService;

        public CreditCardController(ILogger<CreditCardController> logger, ICreditCardService creditCardService)
        {
            _logger = logger;
            _creditCardService = creditCardService;
        }

        /// <summary>
        /// Validate Card Number
        /// This endpoint validates a credit card number using the Luhn algorithm.
        /// </summary>
        /// <param name="cardNumber">The credit card number to validate.</param>
        /// <returns>APIResponse containing the formatted card number if valid, or error details if invalid.</returns>
        /// <response code="200">Returns the formatted card number if valid.</response>
        /// <response code="400">If the card number is invalid or improperly formatted.</response>
        /// <response code="500">If an unexpected server error occurs.</response>
        [HttpGet("{cardNumber}")]
        [ProducesResponseType(typeof(APIResponse<string>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(APIResponse<string>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Validate(string cardNumber)
        {
            var response = new APIResponse<string>();

            if (string.IsNullOrWhiteSpace(cardNumber))
            {
                LogError(response, new List<string> { "Card number cannot be null or empty." }, HttpStatusCode.BadRequest);
                return StatusCode((int)response.StatusCode, response);
            }

            if (!cardNumber.All(char.IsDigit))
            {
                LogError(response, new List<string> { "Card number must contain only digits." }, HttpStatusCode.BadRequest);
                return StatusCode((int)response.StatusCode, response);
            }

            var result = _creditCardService.ValidateCreditCardNumber(cardNumber);

            if (result.HasError)
            {
                var errorMessages = result.Errors.Select(e => e.ToString()).ToList();

                LogError(response, errorMessages, HttpStatusCode.BadRequest);

                return StatusCode((int)response.StatusCode, response);
            }

            return Ok(result);
        }

        private void LogError<T>(APIResponse<T> response, List<string> errorMessages, HttpStatusCode statusCode)
        {
            response.Errors.Add(errorMessages);
            response.HasError = true;
            response.StatusCode = statusCode;
        }
    }
}