using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQRSApi.Responses
{
    public class Log:BaseClass
    {
        [BsonElement("Request")]
        public string Request { get; set; }
        [BsonElement("Type")]
        public string Type { get; set; }
    }
}
