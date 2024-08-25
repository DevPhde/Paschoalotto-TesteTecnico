using Microsoft.AspNetCore.SignalR;
using UserProject.API.Entities;
using UserProject.API.Interfaces.Hub;
using UserProject.API.Interfaces.Users;

namespace UserProject.API.SignalR.Config
{
    public class UsersHub : Hub, IUsersHub
    {
        private readonly IHubContext<UsersHub> _context;
        private readonly IGetAllUsersHandler _getAllUsersHandler;
        public UsersHub(IHubContext<UsersHub> context, IGetAllUsersHandler getAllUsersHandler)
        {
            _context = context;
            _getAllUsersHandler = getAllUsersHandler;
        }

        public async Task SendUsers()
        {
            List<User> response = await _getAllUsersHandler.Handle();
            await _context.Clients.All.SendAsync("SendUsers", response);
        }
    }
}
