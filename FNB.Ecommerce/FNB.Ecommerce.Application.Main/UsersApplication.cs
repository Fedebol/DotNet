using FNB.Ecommerce.Domain.Interface;
using FNB.Ecommerce.Application.DTO;
using FNB.Ecommerce.Application.Interface;
using FNB.Ecommerce.Transversal.Common;
using AutoMapper;

namespace FNB.Ecommerce.Application.Main
{
    public class UsersApplication : IUsersApplication
    {
        private readonly IUsersDomain _usersDomain;
        private readonly IMapper _mapper;

        public UsersApplication(IUsersDomain usersDomain, IMapper iMapper)
        {
            _usersDomain = usersDomain;
            _mapper = iMapper;
        }
        public Response<UsersDTO> Authenticate(string username, string password)
        {
            var response = new Response<UsersDTO>();
            if(string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                response.Message = "Parametros no pueden ser vacios";
                return response;

            }
            try
            {
                var user = _usersDomain.Authenticate(username, password);
                response.Data = _mapper.Map<UsersDTO>(user);
                response.IsSuccess = true;
                response.Message = "Autenticacion Exitosa";
            }
            catch (InvalidOperationException)
            {
                response.IsSuccess= true;
                response.Message = "Usuario no existe";
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;

        }
    }
}
