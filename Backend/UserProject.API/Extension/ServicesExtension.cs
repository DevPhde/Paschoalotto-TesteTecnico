using ExternalServices;
using Microsoft.EntityFrameworkCore;
using UserProject.API.Handlers.Users;
using UserProject.API.Interfaces.ExternalServices;
using UserProject.API.Interfaces.Hub;
using UserProject.API.Interfaces.Users;
using UserProject.API.Persistence.Context;
using UserProject.API.Persistence.Interfaces;
using UserProject.API.Persistence.Repositories;
using UserProject.API.SignalR.Config;

namespace UserProject.API.Extension
{
    public static class ServicesExtension
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options => options.UseNpgsql(configuration.GetConnectionString("PG")));


            //HUB
            services.AddScoped<IUsersHub, UsersHub>();


            // HANDLERS
            services.AddScoped<IRemoveUserHandler, RemoveUserHandler>();
            services.AddScoped<ICreateUsersHandler, CreateUsersHandler>();
            services.AddScoped<IGetAllUsersHandler, GetAllUsersHandler>();
            services.AddScoped<IGetUserByIdHandler, GetUserByIdHandler>();

            //REPOSITORIES
            services.AddScoped<IUserRepository, UserRepository>();

            //EXTERNAL SERVICE
            services.AddScoped<IExternalApi, ExternalApi>();


            return services;
        }
    }
}
