using FNB.Ecommerce.Domain.Entity;
using FNB.Ecommerce.Domain.Interface;
using FNB.Ecommerce.Infrastructure.Interface;


namespace FNB.Ecommerce.Domain.Core
{
    public class UsersDomain : IUsersDomain
    {
        private readonly IUnitOfWork _unitOfWork;

        public UsersDomain(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Users Authenticate(string username, string password)
        {
            return _unitOfWork.Users.Authenticate(username, password);
        }
    }
}
