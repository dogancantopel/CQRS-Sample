using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQRSApi.Responses
{
    public class BaseClass
    {
        [BsonElement("Id")]
        [BsonId]
        public int Id { get; set; }


    }
}
