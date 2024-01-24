using ClassLibrary.Models;

namespace ClassLibrary.DataRepositories;

public interface IShootingDrillRepository
{
    Task<List<ShootingDrill>> GetAll();
    Task<List<ShootingDrill>> GetAllFromUser(User user);
    Task<ShootingDrill?> Get(int id);
    Task Insert(ShootingDrill shootingDrill);
    Task Update(ShootingDrill shootingDrill);
    Task Delete(int id);
    Task<List<ShootingDrill>> GetAllByB2CId(string b2cId);
}
