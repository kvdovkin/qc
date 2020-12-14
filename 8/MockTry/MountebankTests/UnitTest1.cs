using NUnit.Framework;
using System.Net.Http;

namespace MountebankTests
{
    public class Tests
    {
        public HttpClient client = new HttpClient();

        [TestCase("http://localhost:44302/rate/euro", 200, "{\n    \"euro\": {\n        \"rate\": 90.36\n    }\n}")]
        [TestCase("http://localhost:44302/rate/usdollar", 200, "{\n    \"usdollar\": {\n        \"rate\": 76.21\n    }\n}")]
        [TestCase("http://localhost:44302/rate/tenge", 404, "")]
        public void RateTests(string url, int statusCode, string content)
        {
            var response = client.GetAsync(url).Result;
            Assert.AreEqual(response.StatusCode.GetHashCode(), statusCode);
            Assert.AreEqual(response.Content.ReadAsStringAsync().Result, content);
        }
    }
}