using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json;

namespace Tome
{
    class Wit
    {
        [JsonProperty("_text")]
        public string _text;
        [JsonProperty("entities")]
        public entities Entities;
        [JsonProperty("msg_id")]
        public string msg_id;

        public void Consulta(string value)
        //public string Consulta(string value)
        {
            WebClient client = new WebClient();
            client.Headers.Add("Authorization: Bearer 6R7ZBDGYVCDZIZH2XNCFDMICRSMG2CCC");

            string json = client.DownloadString("https://api.wit.ai/message?v=8/1/2018&q=" + value);
            // return json;


            JsonConvert.PopulateObject(json, this);

        }
    }
 
       
        public class entities
        {
            [JsonProperty("intent")]
            public List<intent> Intent { get; set; }
        [JsonProperty("wikipedia_search_query")]
        public List<wikipedia_search_query> wikipedia_search_query { get; set; }

    }

    public class intent
        {
            [JsonProperty("confidence")]
            public string confidence;
            [JsonProperty("value")]
            public string values;
        }

        public class wikipedia_search_query
    {
        [JsonProperty("suggested")]
        public string suggested;
        [JsonProperty("confidence")]
        public string confidence;
        [JsonProperty("value")]
        public string value;
        [JsonProperty("type")]
        public string type;
        }






}
