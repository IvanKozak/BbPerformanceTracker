using APILibrary.Models;

namespace APILibrary.DataRepositories;

public interface IThreeOnThreeMatchRepository
{
    Task<List<ThreeOnThreeMatch>> GetAll();
    Task<List<ThreeOnThreeMatch>> GetAllFromUser(User user);
    Task<ThreeOnThreeMatch?> Get(int id);
    Task Insert(ThreeOnThreeMatch match);
    Task Update(ThreeOnThreeMatch match);
    Task Delete(int id);
    Task<List<ThreeOnThreeMatch>> GetAllByB2CId(string b2cId);
}
