using ClientLibrary.Models;

namespace ClientLibrary.Services;
public interface IShootingDrillService
{
    Task<List<ShootingDrill>> GetAsync();
}
