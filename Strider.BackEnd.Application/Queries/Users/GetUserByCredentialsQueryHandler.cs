using MediatR;
using Strider.BackEnd.Application.Models.Users;
using Strider.BackEnd.Application.Repositories;
using Strider.BackEnd.Domain.Entities;

namespace Strider.BackEnd.Application.Queries.Auth
{
    public class GetUserByCredentialsQueryHandler(IUserRepository _repository) : IRequestHandler<GetUserByCredentialsQuery, UserModel>
    {
        public async Task<UserModel> Handle(GetUserByCredentialsQuery request, CancellationToken cancellationToken)
        {
            var user = await _repository.GetByCredentials(request.Email, request.Password);
            return MapUserModel(user);
        }

        private UserModel MapUserModel(User user)
        {
            if (user == null)
            {
                return null;
            }

            return new UserModel
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email
            };
        }
    }
}
