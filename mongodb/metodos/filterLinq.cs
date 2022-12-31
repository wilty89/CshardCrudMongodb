using mongodb.models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mongodb.metodos
{
    class filterLinq
    {
      

        public  async Task filtrosAsync(IMongoCollection<dbplus> collection)
        {
            var users = await collection
               .Find(m => m.Edad == 45)
               .SortBy(m => m.Nombre)
               .ToListAsync();

            foreach (var movie in users)
            {
                Console.WriteLine(movie.Nombre);
            }

            var users2 = collection
                .AsQueryable()
                .Where(m => m.Edad == 45)
                .OrderBy(m => m.Nombre);
            foreach (var movie in users2)
            {
                Console.WriteLine(movie.Cargo);
            }

            var users3 = from m in collection.AsQueryable()
                         where m.Edad == 45
                         orderby m.Nombre
                         select m;
            foreach (var movie in users3)
            {
                Console.WriteLine(movie.Edad);
            }
        }
    }
}
