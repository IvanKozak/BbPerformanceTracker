using ClassLibrary.Models;

namespace ClassLibrary.DataRepositories;

public interface IUserRepository
{
    Task<List<User>> GetAll();
    Task<User> Get(int id);
    Task Insert(User user);
    Task Update(User user);
    Task Delete(int id);
}