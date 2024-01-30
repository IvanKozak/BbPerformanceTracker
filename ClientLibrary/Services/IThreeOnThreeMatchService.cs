using ClientLibrary.Models;

namespace ClientLibrary.Services;
public interface IThreeOnThreeMatchService
{
    Task AddAsync(ThreeOnThreeMatch match);
    Task<List<ThreeOnThreeMatch>> GetAsync();
    Task<List<ThreeOnThreeMatch>> GetByUserIdAsync(int id);
}