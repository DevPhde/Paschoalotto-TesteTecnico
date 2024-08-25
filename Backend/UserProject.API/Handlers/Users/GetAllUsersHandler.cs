using UserProject.API.Entities;
using UserProject.API.Interfaces.Users;
using UserProject.API.Persistence.Interfaces;

namespace UserProject.API.Handlers.Users
{
    public class GetAllUsersHandler : IGetAllUsersHandler
    {
        private readonly IUserRepository _userRepository;
        public GetAllUsersHandler(IUserRepository userRepository) => _userRepository = userRepository;
        public async Task<List<User>> Handle()
        {
            var a = await _userRepository.GetAllUsersAsync();
            return await _userRepository.GetAllUsersAsync();
        }
    }
}
