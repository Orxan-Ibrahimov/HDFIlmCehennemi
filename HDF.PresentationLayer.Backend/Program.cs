using HDF.BusinessLayer.Abstract;
using HDF.BusinessLayer.Concrete;
using HDF.DAL.Abstract;
using HDF.DAL.Context;
using HDF.DAL.EntityFrameWork;
using HDF.EntityLayer.Concrete;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<HDFContext>();
builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<HDFContext>();

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

//FilmOrSerie
builder.Services.AddScoped<IFilmOrSerieDAL, EFFilmOrSerieDAL>();
builder.Services.AddScoped<IFilmOrSerieService, FilmOrSerieManager>();

//Movie
builder.Services.AddScoped<IMovieDAL, EFMovieDAL>();
builder.Services.AddScoped<IMovieService, MovieManager>();

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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=country}/{action=Index}/{id?}");

app.Run();
