using MongoDB.Driver;
using mongodb.models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using MongoDB.Bson;
using System.Xml;

namespace mongodb.metodos
{
     class MetodosDB
    {

        
        public void CreateData(dbplus people, IMongoCollection<dbplus> collection)
        {
            collection.InsertOne(people);
            //await getwilber.InsertOneAsync(people);
        }
        public  void ReadData(IMongoCollection<dbplus> collection, MongoClient client)
        {
            List<dbplus> dbplus = collection.Find(x => true).ToList();
            foreach (var doc in dbplus)
            {
                //Console.WriteLine(doc.ToJson());
            }
            var firstDocument = collection.Find(new BsonDocument()).FirstOrDefault();
            //Console.WriteLine(firstDocument.ToJson());

            var dbList = client.ListDatabases().ToList();
            Console.WriteLine("The list of databases on this server is: ");
            foreach (var db in dbList)
            {
                Console.WriteLine(db);
            }
            var docs = collection.Find(new BsonDocument()).Project("{_id: 0}").ToList();
            Console.WriteLine("Elementos de la tabla ");
            docs.ForEach(doc =>
            {
                Console.WriteLine(doc);
            });
        }
        public void UpdateData(string Nombre, string NewNombre, IMongoCollection<dbplus> collection)
        {
            var filter = Builders<dbplus>.Filter.Eq("Nombre", Nombre);
            var update = Builders<dbplus>.Update.Set("Nombre", NewNombre);
            collection.UpdateOne(filter, update);
        }
        public void DeleteData(string Nombre, IMongoCollection<dbplus> collection)
        {
            var filterdelete = Builders<dbplus>.Filter.Eq("Nombre", Nombre);
            collection.DeleteOne(filterdelete);
        }
    }
}
