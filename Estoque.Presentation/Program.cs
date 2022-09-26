var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddAuthentication("Identity.Login")
    .AddCookie("Identity.Login", config =>
    {
        config.Cookie.Name = "Identity.Login";
        config.LoginPath = "/Usuario";
        config.AccessDeniedPath = "/Home";
        config.ExpireTimeSpan = TimeSpan.FromHours(1);
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseAuthentication();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Acesso}/{action=Create}/{id?}");

app.Run();
