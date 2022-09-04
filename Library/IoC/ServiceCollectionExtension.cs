using Microsoft.Extensions.DependencyInjection;
using Library.Models.Library;
using Library.Repositories;
using Library.Services;

namespace Library.IoC
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection WithLibraryModule(this IServiceCollection serviceCollection)
        {
            return serviceCollection
                    .AddScoped<IBookService, BookService>()
                    .AddScoped<IBookRepository, BookRepository>()
                    .AddAutoMapper(typeof(MappingProfile));
        }
    }
}
