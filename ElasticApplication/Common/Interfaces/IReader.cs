using System;
using System.Collections.Generic;
using System.Text;

namespace ElasticApplication.Common.Interfaces
{
    public interface IReader
    {   // read data from the file and convert it into json of type t
        List<T> read<T>(string path);
    }
}
