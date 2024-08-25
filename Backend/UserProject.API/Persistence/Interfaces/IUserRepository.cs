using UserProject.API.Entities;

namespace UserProject.API.Persistence.Interfaces
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllUsersAsync();
        Task<User?> GetUserByIdAsync(int userId);
        Task RemoveUserAsync(User user);
        Task<List<User>> CreateListAddAsync(List<User> user);
    }
}
