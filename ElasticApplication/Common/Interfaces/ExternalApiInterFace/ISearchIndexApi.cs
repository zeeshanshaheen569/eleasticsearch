using ElasticApplication.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElasticApplication.Common.Interfaces.ExternalApiInterFace
{
    public interface ISearchIndexApi
    {

        string searchInIndex(SearchRequest searchRequest, string url);
    }
}
