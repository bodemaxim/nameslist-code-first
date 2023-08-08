using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NamesList.Context;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
var builder = WebApplication.CreateBuilder(args);

/*
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("*");
                      });
});
*/
builder.Services.AddCors(opt =>
{
    opt.DefaultPolicyName = "default";
    opt.AddDefaultPolicy(b =>
    {
        b.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
    });
});


// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddControllers(); //для swagger
builder.Services.AddEndpointsApiExplorer(); //для swagger
builder.Services.AddSwaggerGen(); //для swagger

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


//if для swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseRouting();

app.UseCors("default");

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Names}/{action=Index}/{id?}");

app.Run();
