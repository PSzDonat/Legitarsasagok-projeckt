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
    [Route("flights")]
    [ApiController]
    public class FlightController : ControllerBase
    {
        // GET: api/<FlightController>
        [HttpGet]
        public DbSet<Menetrend> Get()
        {
            DataBaseContext app = new DataBaseContext();
            return app.Menetrend;

        }

        // GET api/<FlightController>/5
        [HttpGet("{id}")]
        public List<Menetrend> Get(int id)
        {
            DataBaseContext app = new DataBaseContext();
            return app.Menetrend.Where(x => x.ID == id).ToList();
        }

        // POST api/<FlightController>
        [HttpPost]
        public void Post([FromBody] Menetrend value)
        {
            DataBaseContext app = new DataBaseContext();
            app.Menetrend.Add(value);
            app.SaveChanges();

        }

        // PUT api/<FlightController>/5
        [HttpPut("{id}")]
        public void Put(uint id, [FromBody] Menetrend value)
        {
            DataBaseContext app = new DataBaseContext();
            var find = app.Menetrend.Find(id);
            find.RepuloJarat_ID = value.RepuloJarat_ID;
            find.FelszallasIdopontja = value.FelszallasIdopontja;
            find.LelszallasIdopontja = value.LelszallasIdopontja;
            find.Ara = value.Ara;
            find.RepuloJaratok = value.RepuloJaratok;
            app.SaveChanges();
        }

        // DELETE api/<FlightController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            DataBaseContext app = new DataBaseContext();
            Menetrend indexData = app.Menetrend.Where(x => x.ID == id).ToList()[0];
            app.Menetrend.Remove(indexData);
            app.SaveChanges();
        }
    }
}
