using FNB.Ecommerce.Domain.Entity;

namespace FNB.Ecommerce.Infrastructure.Interface
{
    public interface IUsersRepository : IGenericRepository<Users>
    {
        Users Authenticate(string username, string password);

    }
}
