using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NamesList.Context;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddControllers(); //��� swagger �� ������ ����� �� �����������
builder.Services.AddEndpointsApiExplorer(); //��� swagger
builder.Services.AddSwaggerGen(); //��� swagger

//Register ApplicationDbContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{

    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();


//if ��� swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Names}/{action=Index}/{id?}");

app.Run();
