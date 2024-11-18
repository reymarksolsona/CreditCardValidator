using CreditCardValidator.Models.Dto;
using CreditCardValidator.Services.Interface;
using Microsoft.Extensions.Logging;

namespace CreditCardValidator.Services
{
    public class CreditCardService: ICreditCardService
    {
        private readonly ILogger<CreditCardService> _logger;

        public CreditCardService(ILogger<CreditCardService> logger)
        {
            _logger = logger;
        }

        public APIResponse<bool> ValidateCreditCardNumber(string cardNumber) {
            return new APIResponse<bool>() { Data = true };
        }
    }
}
