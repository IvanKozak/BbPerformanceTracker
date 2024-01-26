using ClassLibrary.DataRepositories;
using ClassLibrary.Models;

namespace API.Endpoints;

public static class UserEndpoints
{
    public static void ConfigureUserEndpoints(this WebApplication app)
    {
        app.MapGet("/users/current", GetUser).RequireAuthorization("User");
        app.MapGet("/users", GetUsers).RequireAuthorization("Admin");
        app.MapGet("users/{id}", GetUserById).RequireAuthorization("Admin");
        app.MapPost("/users", InsertUser).RequireAuthorization("User");
        app.MapPut("/users", UpdateUser).RequireAuthorization("User");
        app.MapDelete("users/{id}", DeleteUser).RequireAuthorization("Admin");
    }

    public static void AddUserServices(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();
    }
    private static async Task<IResult> GetUser(IUserRepository userRepo, IHttpContextAccessor contextAccessor)
    {
        try
        {
            var B2CIdentifier = contextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "sub")?.Value;
            return Results.Ok(await userRepo.GetFromAuthentication(B2CIdentifier));
        }
        catch (Exception ex)
        {

            return Results.Problem(ex.Message);
        }
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

    private static async Task<IResult> InsertUser(IUserRepository userRepo, User user, IHttpContextAccessor contextAccessor)
    {
        try
        {
            var B2CIdentifier = contextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "sub")?.Value;

            if (user.B2CIdentifier == B2CIdentifier)
            {
                await userRepo.Insert(user);
                return Results.Ok();
            }
            return Results.Forbid();
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

    private static async Task<IResult> UpdateUser(IUserRepository userRepo, User user, IHttpContextAccessor contextAccessor)
    {
        try
        {
            var B2CIdentifier = contextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "sub")?.Value;

            if (user.B2CIdentifier == B2CIdentifier)
            {
                await userRepo.Update(user);
                return Results.Ok();
            }
            return Results.Forbid();
        }
        catch (Exception ex)
        {

            return Results.Problem(ex.Message);
        }
    }
}
