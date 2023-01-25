using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Projeto02.GestaoForum.Models;
using Projeto03.AcessoDados.DI;

var builder = WebApplication.CreateBuilder(args);

ConfigurationManager config = builder.Configuration;

// Add services to the container.
//builder.Services.AddDbContext<ForumContext>(options => 
//    options.UseSqlServer(config.GetConnectionString("ForumConnection")));

builder.Services.AddInfraStructureDb(config);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(config.GetConnectionString("IdentityConnection")));

builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequiredLength = 8;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
});

//personalizando o caminho do login, logout e acesso negado
builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Autenticacao/Login";
    options.LogoutPath = "/Autenticacao/Logout";
    options.AccessDeniedPath = "/Autenticacao/AcessDenied";
});

builder.Services.AddControllersWithViews();

var app = builder.Build();

// obtendo a referencia ao objeto fornecido via DI (Dependency Injection)
var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;

//var context = services.GetRequiredService<ForumContext>();
//DbInitializer.Initialize(context);

// criando os perfis (roles)
Utils.CreateRoles(services).Wait();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
