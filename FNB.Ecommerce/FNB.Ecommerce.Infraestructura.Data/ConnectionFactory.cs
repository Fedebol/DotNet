using FNB.Ecommerce.Transversal.Common;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;


namespace FNB.Ecommerce.Infrastructure.Data
{
    public class ConnectionFactory : IConnectionFactory
    {
        private readonly IConfiguration _configuration;

        public ConnectionFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IDbConnection GetConnection
        {
            get
            {
                var sqlConnetion = new SqlConnection();
                if (sqlConnetion == null) return null;

                sqlConnetion.ConnectionString = _configuration.GetConnectionString("NorthwindConnection");
                sqlConnetion.Open();
                return sqlConnetion;            
                                
            }
        }
    }
}