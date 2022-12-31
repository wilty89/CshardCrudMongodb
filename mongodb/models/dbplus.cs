using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Attributes;

namespace mongodb.models
{
  public  class dbplus
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string id { get; set; }


        [BsonElement("Nombre")]
        public string Nombre { get; set; }
        [BsonElement("Edad")]
        public int Edad { get; set; }
        [BsonElement("Cargo")]
        public string Cargo { get; set; }
        [BsonElement("Activo")]
        public bool Activo { get;  set; }
    }
}
