using CreditCardValidator.Models.Dto;

namespace CreditCardValidator.Tests.TestData
{
    public static class CardNumberTestData
    {
        public static string ValidCardNumber => "4539148803436467";
        public static string ValidFormattedCardNumber => "4539 1488 0343 6467";

        public static string InvalidCardNumber => "1234567890123456";

        public static string EmptyCardNumber => string.Empty;

        public static string CardNumberWithNonDigits => "4539a1488b0343c";

        public static APIResponse<string> ValidCardApiResponse()
        {
            return new APIResponse<string>
            {
                Data = ValidFormattedCardNumber,
                HasError = false
            };
        }

        public static APIResponse<string> InvalidCardApiResponse()
        {
            return new APIResponse<string>
            {
                HasError = true,
                Errors = new List<string> { "Invalid card number." }
            };
        }

        public static APIResponse<string> EmptyCardApiResponse()
        {
            return new APIResponse<string>
            {
                HasError = true,
                Errors = new List<string> { "Card number cannot be null or empty." }
            };
        }

        public static APIResponse<string> NonDigitsCardApiResponse()
        {
            return new APIResponse<string>
            {
                HasError = true,
                Errors = new List<string> { "Card number must contain only digits." }
            };
        }
    }
}
