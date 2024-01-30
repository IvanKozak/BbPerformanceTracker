using APILibrary.DataRepositories;
using APILibrary.Models;

namespace API.Endpoints;

public static class ShootingDrillEndpoints
{

    public static void ConfigureShootingDrillEndpoints(this WebApplication app)
    {
        app.MapGet("/users/{id}/shootingdrills", GetShootingDrillsByUserId).RequireAuthorization("Admin");
        app.MapGet("/shootingdrills", GetAllShootingDrills).RequireAuthorization("User");
        app.MapPost("/shootingdrills", InsertShootingDrill).RequireAuthorization("User");
        app.MapPut("/shootingdrills", UpdateShootingDrill).RequireAuthorization("User");
        app.MapDelete("/shootingdrills/{id}", DeleteShootingDrill).RequireAuthorization("User");
    }

    public static void AddShootingDrillServices(this IServiceCollection services)
    {
        services.AddScoped<IShootingDrillRepository, ShootingDrillRepository>();
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

    private static async Task<IResult> GetAllShootingDrills(IShootingDrillRepository shootingDrillRepo, IHttpContextAccessor contextAccessor)
    {
        try
        {
            var b2cId = contextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "sub")?.Value;
            return Results.Ok(await shootingDrillRepo.GetAllByB2CId(b2cId));
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> InsertShootingDrill(IShootingDrillRepository shootingDrillRepo, ShootingDrill drill, IHttpContextAccessor contextAccessor)
    {
        try
        {
            drill.User.B2CIdentifier = contextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "sub")?.Value;
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
