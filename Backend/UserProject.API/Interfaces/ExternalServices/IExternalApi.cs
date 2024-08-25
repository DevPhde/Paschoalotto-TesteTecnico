using UserProject.API.Entities;

namespace UserProject.API.Interfaces.ExternalServices
{
    public interface IExternalApi
    {
        Task<List<User>> GetUsers(int numberOfUsers);
    }
}
