using FlipFlop.Services.Impl;
using FlipFlop.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace FlipFlop.Services
{
    public static class Injection
    {
        public static IServiceCollection AddServices(this IServiceCollection services) 
        {

            services.AddTransient<ICommentService, CommentService>();
            services.AddTransient<IImageService, ImageService>();
            services.AddTransient<IPostService, PostService>();
            services.AddTransient<IUserService, UserService>();

            return services;
        }
    }
}