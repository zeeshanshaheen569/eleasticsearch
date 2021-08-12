using ElasticApplication.Common.Interfaces.ExternalApiInterFace;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace ElasticInfrastrucre.ExternalApi
{
    public class CreateIndexApi : ICreateIndexApi
    {
        private readonly IHttpClientFactory _HttpClientFactory;


        public CreateIndexApi(IHttpClientFactory httpClientFactory)
        {
            _HttpClientFactory = httpClientFactory;
        }

        public bool createIndexByBulkData(string filePath, string url)
        {
            using (var client = _HttpClientFactory.CreateClient())
            {

                string result;
                using (StreamReader streamReader = new StreamReader(filePath))
                {
                    result = streamReader.ReadToEnd();
                }
                var base64authorization = Convert.ToBase64String(Encoding.ASCII.GetBytes("username:password"));
                client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", $"Basic {base64authorization}");
                var request = new HttpRequestMessage(new HttpMethod("POST"), url);
                request.Content = new StringContent(result);
                request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/x-ndjson");

                var httpResponse = client.SendAsync(request).Result;
                if (httpResponse.StatusCode == System.Net.HttpStatusCode.OK)
                {

                    return true;
                }


            }
            return false;
        }

        public bool createIndexMapping(string url, string mappings)
        {
            var jsonQuery = JObject.Parse(mappings);

            using (var client = _HttpClientFactory.CreateClient())
            {

                var base64authorization = Convert.ToBase64String(Encoding.ASCII.GetBytes("username:password"));
                client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", $"Basic {base64authorization}");
                var httpResponse = client.PutAsJsonAsync(url, jsonQuery).Result;

                if (httpResponse.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return true;

                }


            }
            return false;
        }
    }
}
