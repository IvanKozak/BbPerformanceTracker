using MvxCore.Models;

namespace MvxCore.Repositories;
public interface IThreeOnThreeMatchRepository
{
    Task AddAsync(ThreeOnThreeMatch match);
    Task<List<ThreeOnThreeMatch>> GetAsync();
    Task<List<ThreeOnThreeMatch>> GetByUserIdAsync(int id);
}
