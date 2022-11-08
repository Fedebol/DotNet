using FNB.Ecommerce.Domain.Entity;

namespace FNB.Ecommerce.Domain.Interface
{
    public interface IUsersDomain
    {
        Users Authenticate(string username, string password);

    }
}
