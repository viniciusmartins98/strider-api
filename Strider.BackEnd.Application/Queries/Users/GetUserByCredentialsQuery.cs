using MediatR;
using Strider.BackEnd.Application.Models.Users;

namespace Strider.BackEnd.Application.Queries.Auth
{
    public class GetUserByCredentialsQuery : IRequest<UserModel>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
