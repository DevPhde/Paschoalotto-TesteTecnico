using UserProject.API.Entities;
using UserProject.API.Exceptions;
using UserProject.API.Interfaces.Users;
using UserProject.API.Persistence.Interfaces;

namespace UserProject.API.Handlers.Users
{
    public class GetUserByIdHandler : IGetUserByIdHandler
    {
        private readonly IUserRepository _userRepository;
        public GetUserByIdHandler(IUserRepository userRepository) => _userRepository = userRepository;
        public async Task<User> Handle(int userId)
        {
            return await _userRepository.GetUserByIdAsync(userId) ?? throw new NotFoundException("Usuário não encontrado.");
        }
    }
}
