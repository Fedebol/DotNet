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

        }

        [TestMethod]
        public void TestMethod1()
        {
        }
    }
}