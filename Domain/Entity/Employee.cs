using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace MsEmployee.Domain.Entity
{
    public class Employee
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonIgnoreIfDefault]
        public string Id { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("documentNumber")]
        public string DocumentNumber { get; set; }

        [BsonElement("department")]
        public string Department { get; set; }

        [BsonElement("hiringDate")]
        public DateTime HiringDate { get; set; }
    }
}
