using FNB.Ecommerce.Domain.Entity;
using FNB.Ecommerce.Domain.Interface;
using FNB.Ecommerce.Infrastructure.Interface;


namespace FNB.Ecommerce.Domain.Core
{
    public class UsersDomain : IUsersDomain
    {
        private readonly IUsersRepository _usersRepository;

        public UsersDomain(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public Users Authenticate(string username, string password)
        {
            return _usersRepository.Authenticate(username, password);
        }
    }
}
