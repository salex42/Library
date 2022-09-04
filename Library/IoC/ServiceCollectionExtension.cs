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
                    .AddScoped<IBaseRepository<Book>, BaseRepository<Book>>()
                    .AddAutoMapper(typeof(MappingProfile));
        }
    }
}
