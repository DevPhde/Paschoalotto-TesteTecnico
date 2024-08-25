using UserProject.API.Entities;
using UserProject.API.Interfaces.ExternalServices;
using UserProject.API.Interfaces.Users;
using UserProject.API.Persistence.Interfaces;

namespace UserProject.API.Handlers.Users
{
    public class CreateUsersHandler : ICreateUsersHandler
    {
        private readonly IUserRepository _userRepository;
        private readonly IExternalApi _externalApi;

        public CreateUsersHandler(IUserRepository userRepository, IExternalApi externalApi)
        {
            _userRepository = userRepository;
            _externalApi = externalApi;
        }

        public async Task<List<User>> Handle(int numberOfUsers)
        {
            List<User> users = await _externalApi.GetUsers(numberOfUsers);

            await _userRepository.CreateListAddAsync(users);

            return users;
        }
    }
}
