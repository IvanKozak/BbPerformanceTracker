using APILibrary.DataAccess;
using APILibrary.Models;

namespace APILibrary.DataRepositories;

public class UserRepository : IUserRepository
{
    private readonly ISqlDataAccess _db;

    public UserRepository(ISqlDataAccess db)
    {
        _db = db;
    }

    public async Task<IEnumerable<User>> GetAll()
    {
        return await _db.LoadData<User, object>("spUser_GetAll", new { });
    }

    public async Task<User?> Get(int id)
    {
        var result = await _db.LoadData<User, object>("spUser_GetById", new { Id = id });
        return result.FirstOrDefault();
    }

    public async Task<User?> GetFromAuthentication(string b2cId)
    {
        var result = await _db.LoadData<User, object>("spUser_GetByB2CId", new { B2CIdentifier = b2cId });
        return result.FirstOrDefault();
    }

    public Task Insert(User user)
    {
        return _db.SaveData<object>("spUser_Insert", new { user.Nickname, user.B2CIdentifier });
    }

    public Task Update(User user)
    {
        return _db.SaveData("spUser_Update", user);
    }

    public Task Delete(int id)
    {
        return _db.SaveData<object>("spDeleteUser", new { Id = id });
    }
}
