using ElasticApplication.Common.Interfaces;
using ElasticApplication.Common.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
namespace ElasticInfrastrucre.Write
{
    class Writer : IWriter
    {
        public bool WriteManagemntData(IEnumerable<FormatedManagement> formatedMangments, string filePath)
        {
            try
            {
                using (StreamWriter stream = File.CreateText(Path.Combine(Directory.GetCurrentDirectory(), $"{filePath}")))
                {
                    JsonSerializer serializer = new JsonSerializer();

                    foreach (var item in formatedMangments)
                    {
                        var indexProperty = new { index = item.index };
                        var jsonIndex = JsonConvert.SerializeObject(indexProperty);

                        var jsonFeilds = JsonConvert.SerializeObject(
                            item.Fields
                            );

                        stream.WriteLine(jsonIndex);
                        stream.WriteLine(jsonFeilds);




                    }

                }
                return true;
            }
            catch (Exception ex)
            {
                return false;

            }

        }

        public bool WritePropertyData(IEnumerable<FormatedProperty> formatedProperties, string filePath)
        {
            try
            {
                using (StreamWriter stream = File.CreateText(Path.Combine(Directory.GetCurrentDirectory(), $"{filePath}")))
                {
                    JsonSerializer serializer = new JsonSerializer();

                    foreach (var item in formatedProperties)
                    {
                        var indexProperty = new { item.index };
                        var jsonIndex = JsonConvert.SerializeObject(indexProperty);

                        var jsonFeilds = JsonConvert.SerializeObject(
                            item.Fields
                            );

                        stream.WriteLine(jsonIndex);
                        stream.WriteLine(jsonFeilds);




                    }

                }
                return true;
            }
            catch (Exception ex)
            {
                return false;

            }

        }
    }
}
