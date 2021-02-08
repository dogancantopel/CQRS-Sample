using MongoDB.Bson.Serialization.Attributes;
using System;

namespace CQRSApi.Responses
{
    public class Audit: BaseClass
    {
        [BsonElement("UserId")]
        public int UserId { get; set; }
        [BsonElement("SalesPointId")]
        public int SalesPointId { get; set; }
        [BsonElement("ProjectId")]
        public int ProjectId { get; set; }
        [BsonDateTimeOptions(Kind = DateTimeKind.Utc, DateOnly = true)]
        public DateTime StartDate { get; set; }
        [BsonElement("SalesPointName")]
        public string SalesPointName { get; set; }
    }
}