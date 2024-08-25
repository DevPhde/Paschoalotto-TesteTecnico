using UserProject.API.Entities;

namespace UserProject.API.Interfaces.Users
{
    public interface IGetUserByIdHandler
    {
        Task<User> Handle(int userId);
    }
}
