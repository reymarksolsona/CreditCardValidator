using CreditCardValidator.Models.Dto;

namespace CreditCardValidator.Services.Interface
{
    public interface ICreditCardService
    {
        APIResponse<string> ValidateCreditCardNumber(string creditCardNumber);
    }
}