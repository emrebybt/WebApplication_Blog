using BuisnessLayer.Abstract;
using BuisnessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.Data;
using DataAccessLayer.EntityFramework;
using DataAccessLayer.Identity;
using EntityLayer.Abstract;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<BlogContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("ConnStr")));


builder.Services.AddIdentity<AppUser, AppRole>(
           opt =>
           {
               opt.Password.RequireNonAlphanumeric = false;
               opt.Password.RequiredLength = 3;
               opt.Password.RequireUppercase = false;
               opt.Password.RequireLowercase = false;
               opt.Password.RequireDigit = false;

               //opt.User.AllowedUserNameCharacters = "abcdefghijklmnoprstuvyzqw0123456789";

               opt.User.RequireUniqueEmail = true;

               opt.Lockout.MaxFailedAccessAttempts = 3;    //default : 5
               opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(1); //default 5 dk
           }
           ).AddEntityFrameworkStores<BlogContext>();

builder.Services.ConfigureApplicationCookie(opt =>
{
    opt.LoginPath = new PathString("/Account/Login");
    opt.LogoutPath = new PathString("/Account/Logout");
    opt.ExpireTimeSpan = TimeSpan.FromMinutes(10);
    opt.SlidingExpiration = true; //10 dk dolmadan kullanýcý login olursa süre baþtan baþlar.
    opt.Cookie = new CookieBuilder()
    {
        Name = "Identity.App.Cookie",
        HttpOnly = true
    };
});




builder.Services.AddScoped<IBlogService, BlogManager>();
builder.Services.AddScoped<IBlogDal, EfBlogRepository>();
builder.Services.AddScoped<ICommentService, CommentManager>();
builder.Services.AddScoped<ICommentDal, EfCommentRepository>();
builder.Services.AddScoped<ICommentReplyService, CommentReplyManager>();
builder.Services.AddScoped<ICommentReplyDal, EfCommentReplyRepository>();
builder.Services.AddScoped<ICategoryService, CategoryManager>();
builder.Services.AddScoped<ICategoryDal, EfCategoryRepository>();

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

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
    pattern: "{controller=Blog}/{action=Index}/{id?}");

app.Run();
