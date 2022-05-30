using ClassLibrary.DataAccess;
using ClassLibrary.Models;

namespace ClassLibrary.DataRepositories;

public class UserRepository : IUserRepository
{
    private readonly ISqlDataAccess _db;

    public UserRepository(ISqlDataAccess db)
    {
        _db = db;
    }

    public Task<List<User>> GetAll()
    {
        throw new NotImplementedException();
    }

    public async Task<User> Get(int id)
    {
        throw new NotImplementedException();
    }

    public async Task Insert(User user)
    {
        throw new NotImplementedException();
    }

    public async Task Update(User user)
    {
        throw new NotImplementedException();
    }

    public async Task Delete(int id)
    {
        throw new NotImplementedException();
    }
}