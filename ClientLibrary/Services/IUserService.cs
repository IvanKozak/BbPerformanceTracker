using ClientLibrary.Models;

namespace ClientLibrary.Services;
public interface IUserService
{
    Task AddAsync(User user);
    Task<User> GetAsync();
    Task<User> GetByIdAsync(int id);
    Task UpdateAsync(User user);
}