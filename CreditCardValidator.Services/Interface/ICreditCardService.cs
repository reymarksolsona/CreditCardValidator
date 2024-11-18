using CreditCardValidator.Models.Dto;

namespace CreditCardValidator.Services.Interface
{
    public interface ICreditCardService
    {
        APIResponse<bool> ValidateCreditCardNumber(string creditCardNumber);
    }
}