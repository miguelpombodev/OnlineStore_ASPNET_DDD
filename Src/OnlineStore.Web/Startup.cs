using OnlineStore.Domain.Interfaces.Repositories;
using OnlineStore.Domain.Interfaces.Services;
using OnlineStore.Services.Services;
using OnlineStore.Infra.Context;
using OnlineStore.Infra.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Net;
using OnlineStore.Infra.Configuration;
using System.Text;
using Microsoft.OpenApi.Models;
public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }



    public void Configure(WebApplication app, IWebHostEnvironment env, string corsOrigins)
    {

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseRouting();
        ConfigureAuthentication(app, corsOrigins);

        app.MapControllers();

        app.Run();
    }


    public void ConfigureByEnvironment(WebApplication app)
    {
        var smtp = new AppConfiguration.SMTPConfiguration();
        app.Configuration.GetSection("SMTPConfiguration").Bind(smtp);
        AppConfiguration.SMTP = smtp;

        if (app.Environment.IsDevelopment())
        {
            AppConfiguration.IsDevelopment = true;
        }

        AppConfiguration.MainDatabaseConnectionString = app.Configuration.GetConnectionString("MainDatabase");
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddDbContext<DataContext>();
        // services.AddScoped<IBaseRepository<T>, BaseRepository<T>>();
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<ICustomerRepository, CustomerRepository>();
        services.AddScoped<ICustomerService, CustomerService>();
        services.AddScoped<IAccountService, AccountService>();

        services.AddTransient<TokenService>();
        services.AddTransient<HttpClientService>();

        services.AddSingleton<EmailService>();

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(config =>
        {
            config.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.ApiKey
            });
        });
    }

    public void ConfigureAuthentication(WebApplication app, string corsOrigins)
    {
        app.Use(async (context, next) =>
    {
        await next();

        if (context.Response.StatusCode == (int)HttpStatusCode.Unauthorized)
        {
            await context.Response.WriteAsync("Token Validation Has Failed. Request Access Denied");
        }
    });
        app.UseCors(corsOrigins);
        app.UseAuthentication();
        app.UseAuthorization();
    }

    public void ConfigureJWTToken(IServiceCollection services)
    {
        var key = Encoding.ASCII.GetBytes(AppConfiguration.JWTKey);
        services.AddAuthentication(config =>
        {
            config.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            config.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(token =>
        {
            token.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false
            };
        });
    }

}
