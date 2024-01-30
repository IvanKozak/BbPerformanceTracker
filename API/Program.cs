using System.IdentityModel.Tokens.Jwt;
using API.Endpoints;
using APILibrary.DataAccess;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Identity.Web;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<ISqlDataAccess, SqlDataAccess>();
// This is required to be instantiated before the OpenIdConnectOptions starts getting configured.
// By default, the claims mapping will map claim names in the old format to accommodate older SAML applications.
// For instance, 'http://schemas.microsoft.com/ws/2008/06/identity/claims/role' instead of 'roles' claim.
// This flag ensures that the ClaimsIdentity claims collection will be built from the claims in the token
JwtSecurityTokenHandler.DefaultMapInboundClaims = false;

// Adds Microsoft Identity platform (AAD v2.0) support to protect this Api
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddMicrosoftIdentityWebApi(options =>
        {
            builder.Configuration.Bind("AzureAdB2C", options);
        },
options => { builder.Configuration.Bind("AzureAdB2C", options); });

builder.Services.AddAuthorizationBuilder()
  .AddPolicy("User", policy =>
        policy.RequireClaim("scp", "access_as_user"))
  .AddPolicy("Admin", policy =>
  policy
  .RequireClaim("scp", "access_as_user")
  .RequireClaim("jobTitle", "Admin"));

builder.Services.AddUserServices();
builder.Services.AddShootingDrillServices();
builder.Services.AddTOTMatchServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.ConfigureUserEndpoints();
app.ConfigureShootingDrillEndpoints();
app.ConfigureTOTMatchEndpoints();

app.Run();
