using Dapper;
using FNB.Ecommerce.Domain.Entity;
using FNB.Ecommerce.Infrastructure.Interface;
using FNB.Ecommerce.Transversal.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FNB.Ecommerce.Infrastructure.Repository
{
    public class UsersRepository : IUsersRepository
    {
        private readonly IConnectionFactory _connectionFactory;
        public UsersRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public Users Authenticate(string username, string password)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "UserGetByUserAndPassword";
                var parameters = new DynamicParameters();
                parameters.Add("username", username);
                parameters.Add("password", password);

                var user = connection.QuerySingle<Users>(query, param: parameters, commandType: CommandType.StoredProcedure);
                return user;

            }
        }
    }
}
