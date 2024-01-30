using APILibrary.Models;

namespace APILibrary.DataRepositories;

public interface IUserRepository
{
    Task<IEnumerable<User>> GetAll();
    Task<User?> Get(int id);
    Task<User?> GetFromAuthentication(string b2cId);
    Task Insert(User user);
    Task Update(User user);
    Task Delete(int id);
}
