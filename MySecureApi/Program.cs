using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using MySecureApi.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidIssuer = $"{builder.Configuration["Keycloak:BaseUrl"]}/realms/{builder.Configuration["Keycloak:Realm"]}",
        
        ValidateAudience = true,
        ValidAudience = "account",

        ValidateIssuerSigningKey = true,
        ValidateLifetime = false,

        IssuerSigningKeyResolver = (token, securityToken, kid, parameters) =>
        {
            var client = new HttpClient();
            var keyUri = $"{parameters.ValidIssuer}/protocol/openid-connect/certs";
            var response = client.GetAsync(keyUri).Result;
            var keys = new JsonWebKeySet(response.Content.ReadAsStringAsync().Result);

            return keys.GetSigningKeys();
        }
    };

    options.RequireHttpsMetadata = false; // Only in develop environment
    options.SaveToken = true;
});

builder.Services.AddHttpClient();
builder.Services.AddScoped<KeycloakAuthService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.UseAuthentication();
app.UseAuthorization();


app.MapControllers();

app.Run();