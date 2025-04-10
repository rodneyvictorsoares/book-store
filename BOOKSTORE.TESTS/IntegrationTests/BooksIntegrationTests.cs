using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace BOOKSTORE.TESTS.IntegrationTests
{
    public class BooksIntegrationTests : IClassFixture<IntegrationTestServer>
    {
        private readonly HttpClient _client;

        public BooksIntegrationTests(IntegrationTestServer server)
        {
            _client = server.Client;
        }

        [Fact]
        public async Task GetBooks_ReturnsOkAndJsonContent()
        {
            var response = await _client.GetAsync("/api/Books");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var content = await response.Content.ReadAsStringAsync();
            Assert.False(string.IsNullOrEmpty(content));
        }

        [Fact]
        public async Task GetBook_NonExistingId_ReturnsNotFound()
        {
            var response = await _client.GetAsync("/api/Books/9999");
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }
    }
}
