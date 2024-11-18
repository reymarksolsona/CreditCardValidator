using CreditCardValidator.Models.Dto;

namespace CreditCardValidator.Utilities
{
    public class LuhnValidator
    {
        public static bool IsValid<T>(APIResponse<T> response, string cardNumber)
        {
            if (string.IsNullOrWhiteSpace(cardNumber) || !cardNumber.All(char.IsDigit))
            {
                response.Errors.Add("Card number cannot be null or empty and should contain only digits.");
                response.HasError = true;
                return false;
            }

            int sum = 0;
            bool alternate = false;

            for (int i = cardNumber.Length - 1; i >= 0; i--)
            {
                int digit = int.Parse(cardNumber[i].ToString());

                if (alternate)
                {
                    digit *= 2;
                    if (digit > 9)
                        digit -= 9;
                }

                sum += digit;
                alternate = !alternate;
            }

            if (sum % 10 != 0)
            {
                response.Errors.Add("Card number is invalid.");
                response.HasError = true;
                return false;
            }

            return true;
        }
    }
}
