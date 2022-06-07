using ClassLibrary.DataAccess;
using ClassLibrary.Mappers;
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
        var drillDtos = await _db.LoadData<ShootingDrillDto, object>("spGetAllShootingDrillsByUserId", new { UserId = user.Id });
        if (drillDtos is null)
        {
            return new List<ShootingDrill>();
        }
        var output = new List<ShootingDrill>();

        foreach (var drillDto in drillDtos)
        {
            var drill = drillDto.Adapt(user);
            output.Add(drill);
        }

        return output;
    }

    public async Task<ShootingDrill> Get(int id)
    {
        throw new NotImplementedException();
    }

    public Task Insert(ShootingDrill shootingDrill)
    {
        return _db.SaveData<object>("spInsertShootingDrill", shootingDrill.AdaptToDto());
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
