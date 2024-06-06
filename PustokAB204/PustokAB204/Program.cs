using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PustokAB204.Business.DTOs.BookDTOs;
using PustokAB204.Business.Mapping;
using PustokAB204.Business.Services.Abstracts;
using PustokAB204.Business.Services.Concretes;
using PustokAB204.Core.Models;
using PustokAB204.Core.RepositoryAbstracts;
using PustokAB204.Data.DAL;
using PustokAB204.Data.RepositoryConcretes;
using PustokAB204.ViewServices;

namespace PustokAB204
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation().AddFluentValidation(x =>
            {
                x.RegisterValidatorsFromAssemblyContaining(typeof(BookCreateDTOValidator));
            });
            builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);

            //builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies()); 

            builder.Services.AddDbContext<AppDbContext>(opt =>
            {
                opt.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
            });

            builder.Services.AddIdentity<AppUser, IdentityRole>(opt =>
            {
                opt.Password.RequireNonAlphanumeric = true;
                opt.Password.RequireLowercase = true;
                opt.Password.RequireUppercase = true;
                opt.Password.RequireDigit = true;
                opt.Password.RequiredLength = 8;

                opt.User.RequireUniqueEmail = false;

            }).AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();

            builder.Services.AddScoped<LayoutService>();

            builder.Services.AddScoped<IAuthorRepository, AuthorRepository>();
            builder.Services.AddScoped<IAuthorService, AuthorService>();
            builder.Services.AddScoped<IBookService, BookService>();
            builder.Services.AddScoped<IGenreService, GenreService>();
            builder.Services.AddScoped<ITagRepository, TagRepository>();
            builder.Services.AddScoped<ISliderService, SliderService>();
            builder.Services.AddScoped<IFeatureService, FeatureService>();
            builder.Services.AddScoped<IBookRepository, BookRepository>();
            builder.Services.AddScoped<IGenreRepository, GenreRepository>();
            builder.Services.AddScoped<ISliderRepository, SliderRepository>();
            builder.Services.AddScoped<IFeatureRepository, FeatureRepository>();
            var app = builder.Build();

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
                name: "areas",
                pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}"
            );

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}