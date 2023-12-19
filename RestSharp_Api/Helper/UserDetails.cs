using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonPlaceHolder.Helper
{
    //helper class
    public class UserDetails
    {


        [JsonProperty("id")]
        public int Id { get; set; }


        [JsonProperty("userId")]
        public int UserId { get; set; }


        [JsonProperty("title")]
        public string? Title { get; set; }


        [JsonProperty("body")]
        public string? Body { get; set; }



    }
}

