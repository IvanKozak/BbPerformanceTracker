using ClientLibrary.Services;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.Identity.Web;
using Microsoft.Identity.Web.UI;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor().AddMicrosoftIdentityConsentHandler();
builder.Services.AddControllersWithViews().AddMicrosoftIdentityUI();

builder.Services.AddAuthentication(OpenIdConnectDefaults.AuthenticationScheme)
    .AddMicrosoftIdentityWebApp(builder.Configuration.GetSection("AzureAdB2C"))
    .EnableTokenAcquisitionToCallDownstreamApi(new string[] { builder.Configuration.GetValue<string>("UserRecords:Scope") })
    .AddInMemoryTokenCaches();

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Admin", policy =>
    {
        policy.RequireClaim("jobTitle", "Admin");
    });
});


builder.Services.AddUserService(builder.Configuration);
builder.Services.AddShootingDrillService(builder.Configuration);
builder.Services.AddThreeOnThreeMatchService(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseRewriter(
    new RewriteOptions().Add(context =>
    {
        if (context.HttpContext.Request.Path == "/MicrosoftIdentity/Account/SignedOut")
        {
            context.HttpContext.Response.Redirect("/");
        }
    })
    );

app.MapControllers();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
