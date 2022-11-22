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

        public bool Delete(string id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Users Get(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Users> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Users>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Users> GetAsync(string id)
        {
            throw new NotImplementedException();
        }

        public bool Insert(Users entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertAsync(Users entity)
        {
            throw new NotImplementedException();
        }

        public bool Update(Users entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(Users entity)
        {
            throw new NotImplementedException();
        }
    }
       
    
}
