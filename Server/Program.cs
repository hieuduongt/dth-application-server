global using DTHApplication.Server.Services.ProductServices;
global using DTHApplication.Shared;
global using DTHApplication.Shared.Common;
global using Microsoft.EntityFrameworkCore;
using DTHApplication.Server.Services.AuthServices;
using DTHApplication.Server.Services.CategoryServices;
using DTHApplication.Server.Services.FileServices;
using DTHApplication.Server.Services.OrderServices;
using DTHApplication.Server.Services.UserServices;
using DTHApplication.Server.Services.Validations;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<DbContext, DBContext>();
builder.Services.AddDbContext<DBContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
    // options.UseSqlServer(builder.Configuration.GetConnectionString("PrivateConnection"));
});

builder.Services.AddControllersWithViews()
    .AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IImageServices, ImageServices>();
builder.Services.AddScoped<IValidations, Validations>();
builder.Services.AddScoped<ICategoryServies, CategoryServies>();
builder.Services.AddScoped<IProductServices, ProductServices>();
builder.Services.AddScoped<IOrderServices, OrderServices>();
builder.Services.AddScoped<IAuthServices, AuthServices>();
builder.Services.AddScoped<IUserServices, UserServices>();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(builder.Configuration.GetSection("AppSettings:Token").Value)),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });

var app = builder.Build();

app.UseSwaggerUI();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.UseCors(options => options.WithOrigins("http://localhost:3000").AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin());
app.UseSwagger();
app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();

app.UseStaticFiles();

app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(
        Path.Combine(Directory.GetCurrentDirectory(), builder.Configuration["Files:Uploads"])
        ),
    RequestPath = "/" + builder.Configuration["Files:Uploads"]
});


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();