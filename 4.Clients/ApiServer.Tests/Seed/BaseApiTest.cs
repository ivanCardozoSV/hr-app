using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ApiServer.Tests.Seed
{
    [Collection("Api collection")]
    public class BaseApiTest
    {
        protected HttpClient Client { get; }

        protected string ControllerName { get; set; }

        public BaseApiTest(ApiFixture apiFixture)
        {
            Client = apiFixture.Client;
        }

        protected static void AssertSuccess(HttpResponseMessage response, string responseString)
        {
            Assert.True(response.IsSuccessStatusCode,
                            $"Response have a fail code: {response.StatusCode}. Message: {responseString}");
            Assert.NotNull(responseString);
            Assert.NotEmpty(responseString);
        }

        protected async Task<U> Create<T, U>(T model)
        {
            var response = await Client.PostAsync($"/api/{ControllerName}/",
                new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json"));

            var responseString = await response.Content.ReadAsStringAsync();
            AssertSuccess(response, responseString);

            return JsonConvert.DeserializeObject<U>(responseString);
        }
    }
}
