using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

var startup = new Startup(builder.Configuration);

startup.ConfigureSerilog(builder.Host);

startup.ConfigureJWTToken(builder.Services);

builder.Services.AddControllers().AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

startup.ConfigureServices(builder.Services);

var app = builder.Build();

startup.ConfigureAuthentication(app);

var workingPath = Environment.CurrentDirectory;
var projectDirectory = Directory.GetParent(workingPath).Parent.FullName;
startup.ConfigureDotEnv(Path.Combine(projectDirectory, ".env"));
startup.Configure(app, builder.Environment);

