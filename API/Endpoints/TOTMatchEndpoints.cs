using ClassLibrary.DataRepositories;
using ClassLibrary.Models;

namespace API.Endpoints;

public static class TOTMatchEndpoints
{
    public static void ConfigureTOTMatchEndpoints(this WebApplication app)
    {
        app.MapGet("/users/{id}/totmatches", GetTOTMatchesByUserId);
        app.MapGet("/totmatches", GetAllTOTMatches);
        app.MapPost("/totmatches", InsertTOTMatch);
        app.MapPut("/totmatches", UpdateTOTMatch);
        app.MapDelete("/totmatches/{id}", DeleteTOTMatch);
    }

    public static void AddTOTMatchServices(this IServiceCollection services)
    {
        services.AddScoped<IThreeOnThreeMatchRepository, ThreeOnThreeMatchRepository>();
    }

    private static async Task<IResult> GetTOTMatchesByUserId(IUserRepository userRepo, IThreeOnThreeMatchRepository matchRepo, int id)
    {
        try
        {
            var user = await userRepo.Get(id);
            return Results.Ok(await matchRepo.GetAllFromUser(user));
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> GetAllTOTMatches(IThreeOnThreeMatchRepository matchRepo)
    {
        try
        {
            return Results.Ok(await matchRepo.GetAll());
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> InsertTOTMatch(IThreeOnThreeMatchRepository matchRepo, ThreeOnThreeMatch match)
    {
        try
        {
            await matchRepo.Insert(match);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> UpdateTOTMatch(IThreeOnThreeMatchRepository matchRepo, ThreeOnThreeMatch match)
    {
        try
        {
            await matchRepo.Update(match);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> DeleteTOTMatch(IThreeOnThreeMatchRepository matchRepo, int id)
    {
        try
        {
            await matchRepo.Delete(id);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }
}
