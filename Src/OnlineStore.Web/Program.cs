using System.Text.Json.Serialization;
using Serilog;
var builder = WebApplication.CreateBuilder(args);

var startup = new Startup(builder.Configuration);
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(builder.Configuration).CreateLogger();

builder.Host.UseSerilog();

startup.ConfigureJWTToken(builder.Services);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins, policy =>
    {
        policy.AllowAnyOrigin();
        policy.AllowAnyHeader();
        policy.AllowAnyMethod();
    });
});

builder.Services.AddControllers().AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

startup.ConfigureServices(builder.Services);

var app = builder.Build();

app.UseSerilogRequestLogging();

startup.ConfigureByEnvironment(app);
startup.Configure(app, builder.Environment, MyAllowSpecificOrigins);

