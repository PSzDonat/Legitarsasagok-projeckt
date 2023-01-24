using Legitarsasagok_REST_API.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Legitarsasagok_REST_API.Controllers
{
    [Route("airlines")]
    [ApiController]
    public class AirlineController : ControllerBase
    {
        // GET: api/<AirlineController>
        [HttpGet]
        public DbSet<RepuloJaratok> Get()
        {
            DataBaseContext app = new DataBaseContext();
            return app.RepuloJaratok;

        }

        // GET api/<AirlineController>/5
        [HttpGet("{id}")]
        public List<RepuloJaratok> Get(int id)
        {
            DataBaseContext app = new DataBaseContext();
            return app.RepuloJaratok.Where(x => x.ID == id).ToList();
        }

        // POST api/<AirlineController>
        [HttpPost]
        public void Post([FromBody] RepuloJaratok value)
        {
            DataBaseContext app = new DataBaseContext();
            app.RepuloJaratok.Add(value);
            app.SaveChanges();

        }

        // PUT api/<AirlineController>/5
        [HttpPut("{id}")]
        public void Put(uint id, [FromBody] RepuloJaratok value)
        {
            DataBaseContext app = new DataBaseContext();
            var find = app.RepuloJaratok.Find(id);
            find.Legitarsasag = value.Legitarsasag;
            find.Honnan = value.Honnan;
            find.Hova = value.Hova;
            find.Tavolsag = value.Tavolsag;
            find.UtazasiIdo = value.UtazasiIdo;
            find.UtazasiDij = value.UtazasiDij;
            find.Menetrend = value.Menetrend;
            find.Varosok = value.Varosok;
            app.SaveChanges();
        }

        // DELETE api/<AirlineController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            DataBaseContext app = new DataBaseContext();
            
            RepuloJaratok indexData = app.RepuloJaratok.Where(x => x.ID == id).ToList()[0];
            app.RepuloJaratok.Remove(indexData);
            app.SaveChanges();
        }
    }
}
