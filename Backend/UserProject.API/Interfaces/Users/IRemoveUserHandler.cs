namespace UserProject.API.Interfaces.Users
{
    public interface IRemoveUserHandler
    {
        Task Handle(int userId);
    }
}
