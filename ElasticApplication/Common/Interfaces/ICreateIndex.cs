using ElasticApplication.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElasticApplication.Common.Interfaces
{
    // this service serves us to create the index
    public interface ICreateIndex
    {
        bool CreateManagementIndex(string IndexName);

        bool CreatePropertyIndex(string IndexName);


        string CreateMultipleIndex();

    }
}
