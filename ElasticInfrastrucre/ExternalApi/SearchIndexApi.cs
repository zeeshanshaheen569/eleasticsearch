using ElasticApplication.Common.Interfaces.ExternalApiInterFace;
using ElasticApplication.Common.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace ElasticInfrastrucre.ExternalApi
{
    class SearchIndexApi: ISearchIndexApi
    {
        private readonly IHttpClientFactory _HttpClientFactory;

        public SearchIndexApi(IHttpClientFactory HttpClientFactory)
        {
            _HttpClientFactory = HttpClientFactory;
        }

        public string searchInIndex(SearchRequest searchRequest, string url)
        {

            var query = "{ \"from\" : " + searchRequest.From + ",\"size\":" + searchRequest.Limit + ",\"query\":{ \"bool\":{ \"must\":{ \"multi_match\":{ \"query\":\"" + searchRequest.Search.ToString() + "\",\"type\":\"bool_prefix\",\"fields\"" +
                ":[\"name\",\"formerName\",\"city\",\"state\",\"streetAddress\"],\"fuzziness\":1," +
                "\"minimum_should_match\":1}" +
                "},\"filter\":[";
            query = query + (searchRequest.Market != null && searchRequest.Market.Count > 0 ?  "{\"terms\": {\"market\":[\"" + string.Join("\",\"", searchRequest.Market) + "\"]}}" : "") + "]}}}";
            var jsonQuery = JObject.Parse(query);



            using (var client = _HttpClientFactory.CreateClient())
            {

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("username:password"));
                var base64authorization = Convert.ToBase64String(Encoding.ASCII.GetBytes("learning:Qwe123!@#"));
                client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", $"Basic {base64authorization}");
                var httpResponse = client.PostAsJsonAsync(url, jsonQuery).Result;

                if (httpResponse.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return  httpResponse.Content.ReadAsStringAsync().Result;
                    

                }
                return "No result Matched";

            }
        }
    }
}
