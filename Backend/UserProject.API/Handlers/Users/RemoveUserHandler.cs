using UserProject.API.Entities;
using UserProject.API.Exceptions;
using UserProject.API.Interfaces.Users;
using UserProject.API.Persistence.Interfaces;

namespace UserProject.API.Handlers.Users
{
    public class RemoveUserHandler : IRemoveUserHandler
    {
        private readonly IUserRepository _userRepository;
        public RemoveUserHandler(IUserRepository userRepository) => _userRepository = userRepository;
        public async Task Handle(int userId)
        {
            try
            {
                User user = await _userRepository.GetUserByIdAsync(userId) ?? throw new NotFoundException("Usuário não encontrado.");

                await _userRepository.RemoveUserAsync(user);
            } catch (Exception)
            {
                throw;
            }
        }
    }
}
