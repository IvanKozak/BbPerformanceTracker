using ClassLibrary.DataAccess;
using ClassLibrary.Models;

namespace ClassLibrary.DataRepositories;

public class ShootingDrillRepository : IShootingDrillRepository
{
    private readonly ISqlDataAccess _db;

    public ShootingDrillRepository(ISqlDataAccess db)
    {
        _db = db;
    }

    public async Task<List<ShootingDrill>> GetAll()
    {
        throw new NotImplementedException();
    }

    public async Task<List<ShootingDrill>> GetAllFromUser(User user)
    {
        throw new NotImplementedException();
    }

    public async Task<ShootingDrill> Get(int id)
    {
        throw new NotImplementedException();
    }

    public async Task Insert(ShootingDrill shootingDrill)
    {
        throw new NotImplementedException();
    }

    public async Task Update(ShootingDrill shootingDrill)
    {
        throw new NotImplementedException();
    }

    public async Task Delete(int id)
    {
        throw new NotImplementedException();
    }
}