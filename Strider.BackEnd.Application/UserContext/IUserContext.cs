namespace Strider.BackEnd.Application.UserContext
{
    public interface IUserContext
    {
        public int Id { get; }
        public string Name { get; }
        public string Email { get; }
    }
}
