using System;
using System.Collections.Generic;
using System.Text;

namespace ElasticApplication.Common.Interfaces
{
    public interface IMappings
    {
        // get mappings for the index
        string getPropertyIndexMappings();
        string getManagmentIndexMappings();
    }
}
