using ClassLibrary.DataRepositories;
using ClassLibrary.Models;

namespace API.Endpoints;

public static class ShootingDrillEndpoints
{

    public static void ConfigureShootingDrillEndpoints(this WebApplication app)
    {
        app.MapGet("/users/{id}/shootingdrills", GetShootingDrillsByUserId);
        app.MapGet("/shootingdrills", GetAllShootingDrills);
        app.MapPost("/shootingdrills", InsertShootingDrill);
        app.MapPut("/shootingdrills", UpdateShootingDrill);
        app.MapDelete("/shootingdrills/{id}", DeleteShootingDrill);
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

    private static async Task<IResult> GetAllShootingDrills(IShootingDrillRepository shootingDrillRepo)
    {
        try
        {
            return Results.Ok(await shootingDrillRepo.GetAll());
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> InsertShootingDrill(IShootingDrillRepository shootingDrillRepo, ShootingDrill drill)
    {
        try
        {
            await shootingDrillRepo.Insert(drill);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> UpdateShootingDrill(IShootingDrillRepository shootingDrillRepo, ShootingDrill drill)
    {
        try
        {
            await shootingDrillRepo.Update(drill);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> DeleteShootingDrill(IShootingDrillRepository shootingDrillRepo, int id)
    {
        try
        {
            await shootingDrillRepo.Delete(id);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }
}
