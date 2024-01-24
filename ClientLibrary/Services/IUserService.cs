using ClientLibrary.Models;

namespace ClientLibrary.Services;
public interface IUserService
{
    Task<User> GetAsync();
}