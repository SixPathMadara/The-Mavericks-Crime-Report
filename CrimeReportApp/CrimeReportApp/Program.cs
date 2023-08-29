using CrimeReportApp.Data;
using CrimeReportApp.Repositories;
using CrimeReportApp.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configure CORS
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
    builder =>
    {
        builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});

// Add services to the container.
builder.Services.AddDbContext<CrimeContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"), sqlServerOptions => sqlServerOptions.EnableRetryOnFailure()));

builder.Services.AddControllers();
builder.Services.AddScoped<ICrimeRepo, CrimeRepo>();
builder.Services.AddScoped<ICrimeTypeRepo, TypeRepo>();
builder.Services.AddScoped<IUserRepo, UserRepo>();
builder.Services.AddScoped<ICrimeStatsRepo, CrimeStats>();
builder.Services.AddScoped<ICrimeService, CrimeService>();
builder.Services.AddScoped<ICrimeTypeService, CrimeTypeService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ICrimeService, CrimeService>();
builder.Services.AddScoped<ILocationService, LocationService>();
<<<<<<< HEAD
=======
builder.Services.AddScoped<ICrimes, Crimes>();
>>>>>>> b71f5f6e06fe8f267ade1f7ae28f47424818615a

// Add session services and configure
builder.Services.AddDistributedMemoryCache(); // Use an in-memory cache for storing session data
builder.Services.AddSession(options =>
{
    options.Cookie.HttpOnly = true;
    options.IdleTimeout = TimeSpan.FromMinutes(30); // Set the session timeout
});



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
<<<<<<< HEAD

=======
 //d33b7379673a2ece98bfca8e6bae9a444662db37
>>>>>>> b71f5f6e06fe8f267ade1f7ae28f47424818615a
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseCors();
app.UseAuthorization();

app.UseSession(); // Use session middleware

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
