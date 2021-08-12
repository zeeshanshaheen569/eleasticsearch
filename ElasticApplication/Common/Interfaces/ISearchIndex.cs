using ElasticApplication.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElasticApplication.Common.Interfaces
{
    public interface ISearchIndex
    {
        string searchEleastic(SearchRequest searchRequest);
    }
}
