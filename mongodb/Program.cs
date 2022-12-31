using mongodb.models;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using mongodb.metodos;
using System.Threading.Tasks;

namespace mongodb
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("dbplus");
            var collection = database.GetCollection<dbplus>("wilber");

            dbplus people = new dbplus() { Nombre = "Lara Quinoes", Edad = 89, Cargo = "la familia", Activo = true };
            MetodosDB val = new MetodosDB();
            //val.DeleteData("Roche", collection);
            //val.CreateData(people, collection);
            //val.UpdateData("Roche", "Blade", collection);
            val.ReadData(collection, client);

            filterLinq filtros = new filterLinq();
            _ = filtros.filtrosAsync(collection);

           

        }
    }
}
