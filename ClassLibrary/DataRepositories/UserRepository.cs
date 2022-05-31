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

    public async Task<IEnumerable<User>> GetAll()
    {
        return await _db.LoadData<User, object>("spGetAllUsers", new { });
    }

    public async Task<User?> Get(int id)
    {
        var result = await _db.LoadData<User, object>("spGetUserById", new { Id = id });
        return result.FirstOrDefault();
    }

    public Task Insert(User user)
    {
        return _db.SaveData<object>("spInsertUser", new { user.Nickname, user.B2CIdentifier });
    }

    public Task Update(User user)
    {
        return _db.SaveData<User>("spUpdateUser", user);
    }

    public Task Delete(int id)
    {
        return _db.SaveData<object>("spDeleteUser", new { Id = id });
    }
}
