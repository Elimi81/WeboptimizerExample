var builder = WebApplication.CreateBuilder(args);

builder.Services.AddWebOptimizer(options =>
{

	options.AddCssBundle(UIProject.Models.ApplicationSettings.CssBundleName,
		"/css/site.css",		
		"/_content/Razor.Library.Common/lib/ionicons/css/ionicons.css");

	
});



builder.Services.AddControllersWithViews();

//TS.Layouts.TSAsiointi.TSAsiointiLayout layout = new TS.Layouts.TSAsiointi.TSAsiointiLayout(skin: TS.Layouts.TSAsiointi.UiType.Asiakaspalvelu,
//			   components: new TS.Layouts.TSAsiointi.UiComponent[] {
//					TS.Layouts.TSAsiointi.UiComponent.StyleInputs,
//					TS.Layouts.TSAsiointi.UiComponent.Menu,
//					TS.Layouts.TSAsiointi.UiComponent.NewEditorLayout,
//					TS.Layouts.TSAsiointi.UiComponent.jQueryUI
//			   }, commonComponents: new TS.Layouts.Common.UiComponent[] {
//				   TS.Layouts.Common.UiComponent.DuplicateIonicFonts
//			   });

//builder.Services.AddMvc();

//layout.AddCssFileToBundle("css/site.css");

//layout.InitConfigureServices(builder.Services);

var app = builder.Build();


//TS.Layouts.Common.CommonLayout.InitConfigure(app);

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");


}

app.UseStaticFiles();

app.UseRouting();

//app.UseAuthorization();

//app.MapStaticAssets();

app.UseWebOptimizer();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}")
	.WithStaticAssets();


app.Run();
