using ClassLibrary.DataRepositories;
using ClassLibrary.Models;

namespace API;

public static class Api
{
    public static void ConfigureApi(this WebApplication app)
    {
        app.MapGet("/users", GetUsers);
        app.MapPost("/users", InsertUser);
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
}
