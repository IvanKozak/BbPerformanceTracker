using ClientLibrary.Models;

namespace ClientLibrary.Services;
public interface IShootingDrillService
{
    Task AddAsync(ShootingDrill drill);
    Task<List<ShootingDrill>> GetAsync();
    Task<List<ShootingDrill>> GetByUserIdAsync(int id);
}
