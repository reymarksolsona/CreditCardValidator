using CreditCardValidator.Services;
using CreditCardValidator.Services.Interface;

namespace CreditCardValidator.Dependencies
{
    public class DependencyInjectionConfig
    {
        public static void Setup(IServiceCollection services)
        {
            services.AddSingleton<ICreditCardService, CreditCardService>();
        }
    }
}
