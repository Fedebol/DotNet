using FNB.Ecommerce.Domain.Interface;
using FNB.Ecommerce.Application.DTO;
using FNB.Ecommerce.Application.Interface;
using FNB.Ecommerce.Transversal.Common;
using AutoMapper;
using FNB.Ecommerce.Application.Validator;

namespace FNB.Ecommerce.Application.Main
{
    public class UsersApplication : IUsersApplication
    {
        private readonly IUsersDomain _usersDomain;
        private readonly IMapper _mapper;
        private readonly UsersDTOValidator _userDTOvalidator;

        public UsersApplication(IUsersDomain usersDomain, IMapper iMapper, UsersDTOValidator userDTOvalidator)
        {
            _usersDomain = usersDomain;
            _mapper = iMapper;
            _userDTOvalidator = userDTOvalidator;
        }
        public Response<UsersDTO> Authenticate(string username, string password)
        {
            var response = new Response<UsersDTO>();
            var validator = _userDTOvalidator.Validate(new UsersDTO() { UserName = username, Password = password });

            if(!validator.IsValid)
            {
                response.Message = "Errores de validacion";
                response.Errors = validator.Errors;
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
