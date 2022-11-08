using FNB.Ecommerce.Application.DTO;
using FNB.Ecommerce.Transversal.Common;

namespace FNB.Ecommerce.Application.Interface
{
    public interface IUsersApplication 
    {
        Response<UsersDTO> Authenticate(string username, string password);
    }
}
