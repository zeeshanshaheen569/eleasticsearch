using ElasticApplication.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElasticInfrastrucre.Mapper
{
    class Mappings : IMappings
    {
        string IMappings.getManagmentIndexMappings()
        {
            var query = "{\"mappings\":{\"properties\":{\"market\":{\"type\":\"keyword\"," +
                "\"normalizer\":\"lower_normalizer\"},\"mgmtID\":{\"type\":\"integer\",\"index\":false}," +
                "\"name\":{\"type\":\"text\",\"analyzer\":\"custom_analyzer\",\"search_analyzer\":\"custom_stop_analyzer\"," +
                "\"search_quote_analyzer\":\"custom_analyzer\"},\"state\":{\"type\":\"text\"}}}," +
                "\"settings\":{\"analysis\":{\"filter\":{\"english_stop\":{\"ignore_case\":\"true\",\"type\":\"stop\"," +
                "\"stopwords\":[\"and\",\"or\",\"the\",\"into\"]}}," +
                "\"analyzer\":{\"custom_analyzer\":{\"filter\":[\"lowercase\"]," +
                "\"type\":\"custom\",\"tokenizer\":\"standard\"}," +
                "\"custom_stop_analyzer\":{\"filter\":[\"lowercase\",\"english_stop\"]," +
                "\"type\":\"custom\",\"tokenizer\":\"standard\"}},\"normalizer\"" +
                ":{\"lower_normalizer\":{\"type\":\"custom\",\"char_filter\":[],\"filter\":[\"lowercase\",\"asciifolding\"]}}}}}";

            return query;
        }

        string IMappings.getPropertyIndexMappings()
        {
            var query = "{\"mappings\":{\"properties\":{\"market\":{\"type\":\"keyword\"," +
                "\"normalizer\":\"lower_normalizer\"},\"mgmtID\":{\"type\":\"integer\"," +
                "\"index\":false},\"name\":{\"type\":\"text\",\"analyzer\":\"custom_analyzer\"," +
                "\"search_analyzer\":\"custom_stop_analyzer\",\"search_quote_analyzer\":\"custom_analyzer\"}," +
                "\"state\":{\"type\":\"text\"}}},\"settings\":{\"analysis\":{\"filter\":{\"english_stop\":" +
                "{\"ignore_case\":\"true\",\"type\":\"stop\",\"stopwords\":[\"and\",\"or\",\"the\",\"into\"]}}," +
                "\"analyzer\":{\"custom_analyzer\":{\"filter\":[\"lowercase\"],\"type\":\"custom\",\"tokenizer\":" +
                "\"standard\"},\"custom_stop_analyzer\":{\"filter\":[\"lowercase\",\"english_stop\"],\"type\":\"" +
                "custom\",\"tokenizer\":\"standard\"}},\"normalizer\":{\"lower_normalizer\":{\"type\":\"custom\"," +
                "\"char_filter\":[],\"filter\":[\"lowercase\",\"asciifolding\"]}}}}}";
            return query;
        }
    }
}
