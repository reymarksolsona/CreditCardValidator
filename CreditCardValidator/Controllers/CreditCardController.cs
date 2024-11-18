using CreditCardValidator.Services.Interface;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet("{cardNumber}")]
        public IActionResult Validate(string cardNumber)
        {
            if (string.IsNullOrWhiteSpace(cardNumber))
                return BadRequest("Card number cannot be null or empty.");

            if (!cardNumber.All(char.IsDigit))
                return BadRequest("Card number must contain only digits.");

            var result = _creditCardService.ValidateCreditCardNumber(cardNumber);

            return Ok(result);
        }
    }
}