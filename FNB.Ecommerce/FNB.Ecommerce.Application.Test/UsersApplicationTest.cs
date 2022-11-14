using FNB.Ecommerce.Application.Interface;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FNB.Ecommerce.Application.Test
{
    [TestClass]
    public class UsersApplicationTest
    {
        private static IConfiguration _configuration;
        private static IServiceScopeFactory _scopeFactory;

        [ClassInitialize]
        public static void Initialize(TestContext _)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true)
                .AddEnvironmentVariables();
            _configuration = builder.Build();

            
            var services = new ServiceCollection();
            _scopeFactory = services.BuildServiceProvider().GetService<IServiceScopeFactory>();

        }

        [TestMethod]
        public void Authenticate_CaundoNoSeEnvianParametros_RetornaMensajeErrorValidacion()
        {
            using var scope = _scopeFactory.CreateScope();
            var context = scope.ServiceProvider.GetService<IUsersApplication>();

            var userName = string.Empty;
            var password = string.Empty;
            var expected = "Errores de validacion";

            var result = context.Authenticate(userName, password);
            var actual = result.Message;

            Assert.AreEqual(expected, actual);
        }
        
        
    }
}