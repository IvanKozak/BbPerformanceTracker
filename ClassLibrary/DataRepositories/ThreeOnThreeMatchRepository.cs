using ClassLibrary.Models;

namespace ClassLibrary.DataRepositories;

public class ThreeOnThreeMatchRepository : IThreeOnThreeMatchRepository
{
    public Task<List<ThreeOnThreeMatch>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<List<ThreeOnThreeMatch>> GetAllFromUser(User user)
    {
        throw new NotImplementedException();
    }

    public Task<ThreeOnThreeMatch> Get(int id)
    {
        throw new NotImplementedException();
    }

    public Task Insert(ThreeOnThreeMatch match)
    {
        throw new NotImplementedException();
    }

    public Task Update(ThreeOnThreeMatch match)
    {
        throw new NotImplementedException();
    }

    public Task Delete(int id)
    {
        throw new NotImplementedException();
    }
}