using MongoDB.Bson.Serialization.Attributes;
using System;

namespace MongoDB.Model
{
    public class Address
    {
        public Address()
        {
            Id = Guid.NewGuid().ToString();
        }
        [BsonId]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Place { get; set; }
    }
}
