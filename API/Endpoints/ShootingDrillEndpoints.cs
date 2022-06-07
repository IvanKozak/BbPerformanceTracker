using ClassLibrary.DataRepositories;
using ClassLibrary.Models;

namespace API.Endpoints;

public static class ShootingDrillEndpoints
{

    public static void ConfigureShootingDrillEndpoints(this WebApplication app)
    {
        app.MapGet("/users/%id/shootingdrills", GetShootingDrillsByUserId);
        app.MapPost("/shootingdrills", InsertShootingDrill);
    }

    public static void AddShootingDrillServices(this IServiceCollection services)
    {
        services.AddSingleton<IShootingDrillRepository, ShootingDrillRepository>();
    }

    private static async Task<IResult> GetShootingDrillsByUserId(IUserRepository userRepo, IShootingDrillRepository shootingDrillRepo, int id)
    {
        try
        {
            var user = await userRepo.Get(id);
            return Results.Ok(await shootingDrillRepo.GetAllFromUser(user));
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> InsertShootingDrill(IShootingDrillRepository shootingDrillRepo, ShootingDrill shootingDrill)
    {
        try
        {
            await shootingDrillRepo.Insert(shootingDrill);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }
}
