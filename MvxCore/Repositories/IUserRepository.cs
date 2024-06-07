using MvxCore.Models;

namespace MvxCore.Repositories;
public interface IUserRepository
{
    Task AddAsync(User user);
    Task<User> GetAsync();
    Task<User> GetByIdAsync(int id);
    Task UpdateAsync(User user);
}
