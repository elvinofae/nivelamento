using Blog.Appl.Extensions;
using Blog.Appl.Interfaces;
using Blog.Appl.Interfaces.Services;
using Blog.Appl.Service;
using Blog.Domain.Entities;
using Blog.Domain.Interfaces.Repositorys;
using Blog.Infra.Context;
using Blog.Infra.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace Blog.Appl.Config
{
    public static class ServiceConfigurations
    {
        public static void ConfigureCustomServices(IServiceCollection services)
        {
            services.AddScoped<IPostService, PostService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IRepository<Post>, Repository<Post>>();
            services.AddScoped<IRepository<User>, Repository<User>>();
            services.AddScoped<BlogContext, BlogContext>();
            services.AddScoped<ITokenConfiguration, TokenConfiguration>();
            services.ConfigureAutoMapper();
            services.AddSingleton<NotificationService>();
        }
    }
}
