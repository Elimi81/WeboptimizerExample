var builder = WebApplication.CreateBuilder(args);

builder.Services.AddWebOptimizer(options =>
{
	options.AddCssBundle(UIProject.Models.ApplicationSettings.CssBundleName,
		"/css/site.css");
});

builder.Services.AddControllersWithViews();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
}

app.UseStaticFiles();

app.UseRouting();

app.UseWebOptimizer();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}")
	.WithStaticAssets();

app.Run();
