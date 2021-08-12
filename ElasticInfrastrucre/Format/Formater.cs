using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ElasticApplication.Common.Interfaces;
using ElasticApplication.Common.Models;
using ElasticDomain.Entiities;

namespace ElasticInfrastrucre.Format
{
    class Formater : IFormater
    {
        public IEnumerable<FormatedManagement> formatMangment(List<Managment> managments, string indexName)
        {
            var unqieManagement = managments.Select(x => new { x.Mgmt.MgmtID, x.Mgmt.Name, x.Mgmt.Market, x.Mgmt.State }).Distinct();
            var result = unqieManagement.Select((x, index) => new FormatedManagement()
            {
                index = new ManagementIndex()
                {
                    Id = index,
                    IndexName = indexName

                },
                Fields = new ManagmentInfo()
                {
                    Name = x.Name,
                    State = x.State,
                    Market = x.Market,
                    MgmtID = x.MgmtID
                }
            }
            ).Distinct();


            return result;
        }

        public IEnumerable<FormatedProperty> formatProperty(List<Property> properties, string indexName)
        {
            var uniqePropertiest = properties.Select(x => new
            {
                x.property.PropertyID,
                x.property.FormerName,
                x.property.StreetAddress,
                x.property.City,
                x.property.Market,
                x.property.State,
                x.property.Lat,
                x.property.Lng,
                x.property.Name
            }).Distinct();
            var result = uniqePropertiest.Distinct().Select((x, index) => new FormatedProperty()
            {
                index = new PropertyIndex()
                {
                    Id = index,
                    IndexName = indexName
                },
                Fields = new PropertyInfo()
                {
                    Name = x.Name,
                    FormerName = x.FormerName,
                    State = x.State,
                    StreetAddress = x.StreetAddress,
                    City = x.City,
                    Market = x.Market,
                    Lat = x.Lat,
                    Lng = x.Lng,
                    PropertyID = x.PropertyID

                }
            });
        


            return result;
        }
    }
}
