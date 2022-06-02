using ClassLibrary.DataRepositories;
using ClassLibrary.Models;

namespace API.Endpoints;

public static class UserEndpoints
{
    public static void ConfigureUserEndpoints(this WebApplication app)
    {
        app.MapGet("/users", GetUsers);
        app.MapGet("users/%id", GetUserById);
        app.MapPost("/users", InsertUser);
        app.MapPut("/users", UpdateUser);
        app.MapDelete("users/%id", DeleteUser);
    }

    public static void AddUserServices(this IServiceCollection services)
    {
        services.AddSingleton<IUserRepository, UserRepository>();
    }

    private static async Task<IResult> GetUsers(IUserRepository userRepo)
    {
        try
        {
            return Results.Ok(await userRepo.GetAll());
        }
        catch (Exception ex)
        {

            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> InsertUser(IUserRepository userRepo, User user)
    {
        try
        {
            await userRepo.Insert(user);
            return Results.Ok();
        }
        catch (Exception ex)
        {

            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> GetUserById(IUserRepository userRepo, int id)
    {
        try
        {
            return Results.Ok(await userRepo.Get(id));
        }
        catch (Exception ex)
        {

            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> DeleteUser(IUserRepository userRepo, int id)
    {
        try
        {
            await userRepo.Delete(id);
            return Results.Ok();
        }
        catch (Exception ex)
        {

            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> UpdateUser(IUserRepository userRepo, User user)
    {
        try
        {
            await userRepo.Update(user);
            return Results.Ok();
        }
        catch (Exception ex)
        {

            return Results.Problem(ex.Message);
        }
    }
}
