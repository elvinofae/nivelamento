using AutoMapper;
using Blog.Appl.Mappers;
using Microsoft.Extensions.DependencyInjection;

namespace Blog.Appl.Extensions
{
    public static class MapperExtension
    {
        public static void ConfigureAutoMapper(this IServiceCollection services)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<PostProfile>();
                cfg.AddProfile<AuthProfile>();
            });

            IMapper mapper = config.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
