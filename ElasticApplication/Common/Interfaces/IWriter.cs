using ElasticApplication.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElasticApplication.Common.Interfaces
{
    public interface IWriter
    {
        // this will write your json data to the given file
        bool WritePropertyData(IEnumerable<FormatedProperty> formatedProperties, string filePath);
        bool WriteManagemntData(IEnumerable<FormatedManagement> formatedMangments, string filePath);
    }
}
