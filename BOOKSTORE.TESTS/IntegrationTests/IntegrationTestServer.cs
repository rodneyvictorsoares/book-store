using BOOKSTORE.DOMAIN.Interfaces;
using BOOKSTORE.DOMAIN.Models;
using BOOKSTORE.IOC.Context;
using BOOKSTORE.IOC.Repositories;
using BOOKSTORE.WEB.Controllers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BOOKSTORE.TESTS.IntegrationTests
{
    public class IntegrationTestServer : IDisposable
    {
        public TestServer Server { get; }
        public HttpClient Client { get; }

        public IntegrationTestServer()
        {
            var builder = new WebHostBuilder()
                .UseEnvironment("Testing")
                .ConfigureServices(services =>
                {
                    // Adiciona os controllers – garante que o assembly dos controllers seja carregado
                    services.AddControllers()
                            .AddApplicationPart(typeof(BooksController).Assembly);

                    // Remover qualquer registro prévio do AppDbContext, se existir
                    var descriptor = services.SingleOrDefault(
                        d => d.ServiceType == typeof(DbContextOptions<AppDbContext>));
                    if (descriptor != null)
                    {
                        services.Remove(descriptor);
                    }

                    // Registra o AppDbContext usando InMemory para os testes
                    services.AddDbContext<AppDbContext>(options =>
                    {
                        options.UseInMemoryDatabase("TestBookStoreDB");
                    });

                    services.AddScoped<IRepository<Book>, BookRepository>();

                    // Registra o BookService
                    services.AddScoped<BookService>();

                })
                .Configure(app =>
                {
                    // Configura o pipeline de requisição
                    app.UseRouting();

                    app.UseEndpoints(endpoints =>
                    {
                        endpoints.MapControllers(); 
                    });
                });

            // Cria o TestServer e o HttpClient para os testes
            Server = new TestServer(builder);
            Client = Server.CreateClient();
        }

        public void Dispose()
        {
            Client.Dispose();
            Server.Dispose();
        }
    }
}
