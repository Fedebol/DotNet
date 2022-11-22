using Dapper;
using FNB.Ecommerce.Domain.Entity;
using FNB.Ecommerce.Infrastructure.Data;
using FNB.Ecommerce.Infrastructure.Interface;
using System.Data;

namespace FNB.Ecommerce.Infrastructure.Repository
{
    public class UsersRepository : IUsersRepository
    {
        private readonly DapperContext _context;
        public UsersRepository(DapperContext context)
        {
            _context = context;
        }

        public Users Authenticate(string username, string password)
        {
            using (var connection = _context.CreateConnection())
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
