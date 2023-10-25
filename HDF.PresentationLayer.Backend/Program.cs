using HDF.BusinessLayer.Abstract;
using HDF.BusinessLayer.Concrete;
using HDF.DAL.Abstract;
using HDF.DAL.Context;
using HDF.DAL.EntityFrameWork;
using HDF.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<HDFContext>();
builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<HDFContext>();

// Role 
builder.Services.AddScoped<IAppRoleDAL, EFAppRoleDAL>();
builder.Services.AddScoped<IAppRoleService, AppRoleManager>();

// Cast 
builder.Services.AddScoped<ICastDAL, EFCastDAL>();
builder.Services.AddScoped<ICastService, CastManager>();


//Country
builder.Services.AddScoped<ICountryDal, EFCountryDAL>();
builder.Services.AddScoped<ICountryService, CountryManager>();

//Category
builder.Services.AddScoped<ICategoryDAL, EFCategoryDAL>();
builder.Services.AddScoped<ICategoryService, CategoryManager>();

//Kind
builder.Services.AddScoped<IKindDAL, EFKindDAL>();
builder.Services.AddScoped<IKindService, KindManager>();

//Language
builder.Services.AddScoped<ILanguageDAL, EFLanguageDAL>();
builder.Services.AddScoped<ILanguageService, LanguageManager>();

//Movie
builder.Services.AddScoped<IMovieDAL, EFMovieDAL>();
builder.Services.AddScoped<IMovieService, MovieManager>();

//MovieKind
builder.Services.AddScoped<IMovieKindDAL, EFMovieKindDAL>();
builder.Services.AddScoped<IMovieKindService, MovieKindManager>();

//MovieCategory
builder.Services.AddScoped<IMovieCategoryDAL, EFMovieCategoryDAL>();
builder.Services.AddScoped<IMovieCategoryService, MovieCategoryManager>();

//MovieCast
builder.Services.AddScoped<IMovieCastDAL, EFMovieCastDAL>();
builder.Services.AddScoped<IMovieCastService, MovieCastManager>();

//MovieLanguage
builder.Services.AddScoped<IMovieLanguageDAL, EFMovieLanguageDAL>();
builder.Services.AddScoped<IMovieLanguageService, MovieLanguageManager>();

//MovieLanguage
builder.Services.AddScoped<IEpisodeDAL, EFEpisodeDAL>();
builder.Services.AddScoped<IEpisodeService, EpisodeManager>();

//Footer
builder.Services.AddScoped<IFooterDAL, EFFooterDAL>();
builder.Services.AddScoped<IFooterService, FooterManager>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

//app.UseEndpoints(endpoints =>
//{
//    endpoints.MapControllerRoute(
//       name: "areaRoute",
//       pattern: "{area:exists}/{controller=account}/{action=login}/{id?}\"");
//});
//app.UseEndpoints(endpoints =>
//{
//    endpoints.MapControllerRoute(
//        name: "default",
//        pattern: "{controller=Home}/{action=Index}/{id?}");
//});
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapControllerRoute(
    name: "areaRoute",
    pattern: "{area:exists}/{controller=account}/{action=login}/{id?}");

app.Run();
