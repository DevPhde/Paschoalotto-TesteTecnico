using UserProject.API.Entities;

namespace UserProject.API.Interfaces.Users
{
    public interface ICreateUsersHandler
    {
        Task<List<User>> Handle(int numberOfUsers);
    }
}
