using Strider.BackEnd.Domain.Entities;

namespace Strider.BackEnd.Application.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetByCredentials(string email, string password);
        Task<User> GetById(int id);
    }
}
