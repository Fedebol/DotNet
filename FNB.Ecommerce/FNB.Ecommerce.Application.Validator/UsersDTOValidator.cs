using FNB.Ecommerce.Application.DTO;
using FluentValidation;


namespace FNB.Ecommerce.Application.Validator
{
    public class UsersDTOValidator : AbstractValidator<UsersDTO>
    {
        public UsersDTOValidator()
        {
            RuleFor(u => u.UserName).NotNull().NotEmpty();
            RuleFor(u => u.Password).NotNull().NotEmpty();
        }
    }
}