using ClassLibrary.DataAccess;
using ClassLibrary.Mappers;
using ClassLibrary.Models;

namespace ClassLibrary.DataRepositories;

public class ThreeOnThreeMatchRepository : IThreeOnThreeMatchRepository
{
    private readonly ISqlDataAccess _db;

    public ThreeOnThreeMatchRepository(ISqlDataAccess db)
    {
        _db = db;
    }

    public async Task<List<ThreeOnThreeMatch>> GetAll()
    {
        var dtos = await _db.LoadData<TOTMatchJoinUserDto, object>("spTOTMatch_GetAll", new { });

        var matches = new List<ThreeOnThreeMatch>();
        foreach (var dto in dtos)
        {
            matches.Add(dto.Adapt());
        }
        return matches;
    }

    public async Task<List<ThreeOnThreeMatch>> GetAllFromUser(User user)
    {
        var dtos = await _db.LoadData<TOTMatchDto, object>("spTOTMatch_GetAllByUserId", new { UserId = user.Id });

        var matches = new List<ThreeOnThreeMatch>();
        foreach (var dto in dtos)
        {
            matches.Add(dto.Adapt(user));
        }
        return matches;
    }

    public async Task<ThreeOnThreeMatch?> Get(int id)
    {
        var dto = await _db.LoadData<TOTMatchJoinUserDto, object>("spTOTMatch_GetById", new { Id = id });
        return dto.FirstOrDefault()?.Adapt();
    }

    public Task Insert(ThreeOnThreeMatch match)
    {
        return _db.SaveData<TOTMatchDto>("spTOTMatch_Insert", match.AdaptToDto());
    }

    public Task Update(ThreeOnThreeMatch match)
    {
        return _db.SaveData<TOTMatchDto>("spTOTMatch_Update", match.AdaptToDto());
    }

    public Task Delete(int id)
    {
        return _db.SaveData<object>("spTOTMatch_Delete", new { Id = id });
    }
}
