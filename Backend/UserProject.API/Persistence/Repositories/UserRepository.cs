using Microsoft.EntityFrameworkCore;
using UserProject.API.Entities;
using UserProject.API.Exceptions;
using UserProject.API.Persistence.Context;
using UserProject.API.Persistence.Interfaces;

namespace UserProject.API.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<User>> CreateListAddAsync(List<User> users)
        {
            try
            {
                await _context.AddRangeAsync(users);
                await _context.SaveChangesAsync();

                return users;
            } catch (Exception)
            {
                throw new InternalErrorException("Erro interno. Tente novamente mais tarde.");
            }
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _context.Users
                .Include(x => x.Location)
                .Include(x => x.Login)
                .Include(x => x.Picture).ToListAsync();
        }

        public async Task<User?> GetUserByIdAsync(int userId)
        {
            return await _context.Users
                .Include(x => x.Location)
                .Include(x => x.Login)
                .Include(x => x.Picture).FirstOrDefaultAsync(x => x.Id == userId);
        }

        public async Task RemoveUserAsync(User user)
        {
            try
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();

            } catch (Exception)
            {
                throw new InternalErrorException("Erro interno. Tente novamente mais tarde.");
            } 

        }
    }
}
