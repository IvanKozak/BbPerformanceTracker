using ClassLibrary.Models;

namespace ClassLibrary.DataRepositories;

public interface IThreeOnThreeMatchRepository
{
    Task<List<ThreeOnThreeMatch>> GetAll();
    Task<List<ThreeOnThreeMatch>> GetAllFromUser(User user);
    Task<ThreeOnThreeMatch?> Get(int id);
    Task Insert(ThreeOnThreeMatch match);
    Task Update(ThreeOnThreeMatch match);
    Task Delete(int id);
}
