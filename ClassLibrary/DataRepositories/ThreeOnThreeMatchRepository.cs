﻿using APILibrary.DataAccess;
using APILibrary.Mappers;
using APILibrary.Models;

namespace APILibrary.DataRepositories;

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

    public async Task<List<ThreeOnThreeMatch>> GetAllByB2CId(string b2cId)
    {
        var dtos = await _db.LoadData<TOTMatchJoinUserDto, object>("spTOTMatch_GetAllByB2CId", new { B2CIdentifier = b2cId });

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
        return _db.SaveData("spTOTMatch_Insert", match.AdaptToDto());
    }

    public Task Update(ThreeOnThreeMatch match)
    {
        return _db.SaveData("spTOTMatch_Update", match.AdaptToDto());
    }

    public Task Delete(int id)
    {
        return _db.SaveData<object>("spTOTMatch_Delete", new { Id = id });
    }
}
