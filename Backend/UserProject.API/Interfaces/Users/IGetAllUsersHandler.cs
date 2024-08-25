using UserProject.API.Entities;

namespace UserProject.API.Interfaces.Users
{
    public interface IGetAllUsersHandler
    {
        Task<List<User>> Handle();
    }
}
