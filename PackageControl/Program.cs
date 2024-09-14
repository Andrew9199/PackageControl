using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PackageControl.Components;
using PackageControl.Components.Account;
using PackageControl.Data;
using Entities;
using Business;
using DataAccess;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Configure authentication and authorization
builder.Services.AddCascadingAuthenticationState();
builder.Services.AddScoped<IdentityUserAccessor>();
builder.Services.AddScoped<IdentityRedirectManager>();
builder.Services.AddScoped<AuthenticationStateProvider, IdentityRevalidatingAuthenticationStateProvider>();
builder.Services.AddScoped<B_Package>();

// Configure database context
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<PackageControlDataContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

// Configure Identity services
builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
{
    options.SignIn.RequireConfirmedAccount = true;
})
.AddEntityFrameworkStores<PackageControlDataContext>()
.AddDefaultTokenProviders();

// Configure cookie authentication
builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Account/Login";          // Path for login
    options.LogoutPath = "/Account/Logout";        // Path for logout
    options.AccessDeniedPath = "/Account/AccessDenied"; // Path for access denied
    options.Cookie.HttpOnly = true;                // Cookie is only accessible via HTTP
    options.ExpireTimeSpan = TimeSpan.FromMinutes(60); // Session expiration time
    options.SlidingExpiration = true;              // Sliding expiration
});

// Configure email sender (optional, use your own implementation if needed)
builder.Services.AddSingleton<IEmailSender<ApplicationUser>, IdentityNoOpEmailSender>();

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

// Configure routing
app.UseRouting();

app.UseAuthentication(); // Ensure authentication is used before authorization
app.UseAuthorization();  // Ensure authorization is used after authentication

app.UseAntiforgery(); // Ensure antiforgery tokens are validated

// Configure endpoints
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.MapAdditionalIdentityEndpoints(); // Map additional identity endpoints

app.Run();