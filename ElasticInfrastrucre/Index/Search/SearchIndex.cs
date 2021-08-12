using ElasticApplication.Common.Interfaces;
using ElasticApplication.Common.Interfaces.ExternalApiInterFace;
using ElasticApplication.Common.Models;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace ElasticInfrastrucre.Index.Search
{
    class SearchIndex : ISearchIndex
    {

        private readonly ISearchIndexApi _ISearchIndexApi;
        private readonly AppIdentitySettings AppIdentitySettings;
        public SearchIndex(ISearchIndexApi ISearchIndexApi, IOptionsMonitor<AppIdentitySettings> options)
        {
            _ISearchIndexApi = ISearchIndexApi;
            AppIdentitySettings = options.CurrentValue;
        }

        public string searchEleastic(SearchRequest searchRequest)
        {
            var baseUrl = AppIdentitySettings.Urls.BaseUrl + AppIdentitySettings.IndexNames.ManagmentIndexName + "," + AppIdentitySettings.IndexNames.PropertyIndexName+ "/_search?pretty=true";
            return _ISearchIndexApi.searchInIndex(searchRequest, baseUrl);
        }
    }
}
