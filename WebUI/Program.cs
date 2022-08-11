using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using WebUI.InfraStrructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddHttpContextAccessor();


builder.Services.AddScoped<CookieManager, CookieManager>();



builder.Services.AddSession(opt => opt.IdleTimeout = TimeSpan.FromHours(7897));
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = new PathString("/login/Index");
        options.LogoutPath = new PathString("/account/logout");
        options.AccessDeniedPath = new PathString("/login/Index");
        options.ExpireTimeSpan = TimeSpan.FromDays(1);
        options.SlidingExpiration = false; ;
        options.Cookie = new CookieBuilder
        {
            Name = "MovieExample",
            HttpOnly = true,
            SameSite = SameSiteMode.Strict,
            SecurePolicy = CookieSecurePolicy.SameAsRequest,

    };
    });
builder.Services.Configure<CookieTempDataProviderOptions>(options =>
{
    options.Cookie.IsEssential = true;
    options.Cookie.Expiration = TimeSpan.FromHours(798789);
});
builder.Services.AddControllers();

builder.Services.AddRazorPages();
builder.Services.AddControllersWithViews();
var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}



app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseCookiePolicy();

app.UseAuthentication();
app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Index}/{id?}"
    );
app.MapRazorPages();
app.Run();
