using Strider.BackEnd.Application.Repositories;
using Strider.BackEnd.Domain.Entities;

namespace Strider.BackEnd.Infra.Repositories
{
    internal class UserRepository : IUserRepository
    {
        public async Task<User> GetByCredentials(string email, string password)
        {
            return _mockedUser.SingleOrDefault(x => x.Email == email && x.Password == password);
        }

        public async Task<User> GetById(int id)
        {
            return _mockedUser.SingleOrDefault(x => x.Id == id);
        }

        private IEnumerable<User> _mockedUser = [
            new User { Id = 1, Name = "John Doe", Email = "johndoe@test.com", Password = "strider" },
            new User { Id = 2, Name = "Jane Doe", Email = "janedoe@test.com", Password = "strider" },
        ];
    }
}
