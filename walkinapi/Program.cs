using walkinapi.Models;
using Pomelo.EntityFrameworkCore.MySql;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();
// builder.Services.AddAuthentication("CookieAuth").AddCookie("CookieAuth",config=>{
//     config.Cookie.Name="Grandmas.Cookie";
//     config.LoginPath="/login";
// });


builder.Services.AddDbContext<DbEntities>(options =>
{
    string connectionString = builder.Configuration.GetConnectionString("DevConnection");
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseCors(builder=>
builder.WithOrigins("http://localhost:4200"));
app.UseAuthentication();
app.UseAuthorization();


app.MapControllers();

app.Run();
