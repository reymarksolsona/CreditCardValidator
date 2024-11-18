using CreditCardValidator.Models.Dto;
using CreditCardValidator.Services.Interface;
using CreditCardValidator.Utilities;
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

        public APIResponse<string> ValidateCreditCardNumber(string cardNumber) 
        {
            var result = new APIResponse<string>();

            bool isCardNumberValid = LuhnValidator.IsValid(result, cardNumber);

            if (isCardNumberValid) 
            { 
                result.Data = $"Card number: {FormatCardNumber(cardNumber)} is valid.";
            }

            return result;
        }

        private string FormatCardNumber(string cardNumber)
        {
            // Insert a space after every 4 digits
            return string.Join(" ", Enumerable.Range(0, cardNumber.Length / 4)
                                              .Select(i => cardNumber.Substring(i * 4, Math.Min(4, cardNumber.Length - i * 4))));
        }
    }
}
