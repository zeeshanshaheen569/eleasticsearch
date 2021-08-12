using ElasticApplication.Common.Models;
using ElasticDomain.Entiities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElasticApplication.Common.Interfaces
{
    public interface IFormater
    {   // this will formate the index in to new data format and remove duplication on the basis of everyfeild
        IEnumerable<FormatedManagement> formatMangment(List<Managment> managments, string indexName);
        IEnumerable<FormatedProperty> formatProperty(List<Property> properties, string indexName);
    }
}
