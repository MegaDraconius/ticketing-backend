using super_ticketing_backend.DataBaseSettings;
using super_ticketing_backend.Repositories;
using super_ticketing_backend.Services;
using super_ticketing_backend.Services.UserService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddJsonOptions(
        options => options.JsonSerializerOptions.PropertyNamingPolicy = null);;
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<UserService>();
builder.Services.AddSingleton<IUserRepository, UserRepository>(provider =>
{
    var userService = provider.GetRequiredService<UserService>();
    return new UserRepository(userService.GetUsersCollection());
});
builder.Services.Configure<DataBaseSettings>(
    builder.Configuration.GetSection("super-ticketing-backend"));
builder.Services.AddMongoDb(builder.Configuration);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();