using ProductCatalog.Business.Abstract;
using ProductCatalog.Business.Concrete;

namespace ProductCatalog.API.Extensions
{
    public static class ServicesExtensions
    {
        public static void ConfigureLoggerService(this IServiceCollection services) => services.AddSingleton<ILoggerService, LoggerManager>();
    }
}
