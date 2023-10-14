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

//
builder.Services.AddScoped<ICountryDal, EFCountryDAL>();
builder.Services.AddScoped<ICountryService, CountryManager>();

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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
