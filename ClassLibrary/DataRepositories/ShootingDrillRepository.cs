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
        var drillJoinUserDtos = await _db.LoadData<ShootingDrillJoinUserDto, object>("spShootingDrill_GetAll", new { });
        var output = new List<ShootingDrill>();

        foreach (var drillJoinUserDto in drillJoinUserDtos)
        {
            var drill = drillJoinUserDto.Adapt();
            output.Add(drill);
        }

        return output;
    }

    public async Task<List<ShootingDrill>> GetAllByB2CId(string b2cId)
    {
        var drillJoinUserDtos = await _db.LoadData<ShootingDrillJoinUserDto, object>("spShootingDrill_GetAllByB2CId", new { B2CIdentifier = b2cId });
        if (drillJoinUserDtos is null)
        {
            return new List<ShootingDrill>();
        }
        var output = new List<ShootingDrill>();

        foreach (var drillJoinUserDto in drillJoinUserDtos)
        {
            var drill = drillJoinUserDto.Adapt();
            output.Add(drill);
        }

        return output;
    }

    public async Task<List<ShootingDrill>> GetAllFromUser(User user)
    {
        var drillDtos = await _db.LoadData<ShootingDrillDto, object>("spShootingDrill_GetAllByUserId", new { UserId = user.Id });
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

    public async Task<ShootingDrill?> Get(int id)
    {
        var drillDto = await _db.LoadData<ShootingDrillJoinUserDto, object>("spShootingDrill_GetById", new { Id = id });
        return drillDto.FirstOrDefault()?.Adapt();
    }

    public Task Insert(ShootingDrill shootingDrill)
    {
        return _db.SaveData<ShootingDrillDto>("spShootingDrill_Insert", shootingDrill.AdaptToDto());
    }

    public Task Update(ShootingDrill shootingDrill)
    {
        return _db.SaveData<ShootingDrillDto>("spShootingDrill_Update", shootingDrill.AdaptToDto());
    }

    public Task Delete(int id)
    {
        return _db.SaveData<object>("spShootingDrill_Delete", new { Id = id });
    }
}
