using MvxCore.Models;

namespace MvxCore.Repositories;
public interface IShootingDrillRepository
{
    Task AddAsync(ShootingDrill drill);
    Task<List<ShootingDrill>> GetAsync();
    Task<List<ShootingDrill>> GetByUserIdAsync(int id);
}
