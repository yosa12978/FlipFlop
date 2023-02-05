using FlipFlop.EfCore.Data;
using FlipFlop.EfCore.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace FlipFlop.EfCore
{
    public static class Injection
    {
        public static IServiceCollection AddEfCoreRepositories(this IServiceCollection services, string connectionString) 
        {
            services.AddDbContext<FlipFlopContext>(options => 
                options.UseSqlite(connectionString, x => x.MigrationsAssembly("FlipFlop.Migrations")));
            
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IPostRepository, PostRepository>();
            services.AddTransient<IImageRepository, ImageRepository>();
            services.AddTransient<ICommentRepository, CommentRepository>();
            
            return services;
        } 
    }
}