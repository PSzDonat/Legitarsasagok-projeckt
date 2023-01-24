using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Legitarsasagok_REST_API.Controllers;
using Microsoft.EntityFrameworkCore;
using Legitarsasagok_REST_API.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Legitarsasagok_REST_API.Controllers
{
    [Route("cities")]
    [ApiController]
    public class CityController : ControllerBase
    {
        // GET: api/<CityController>
        [HttpGet]
        public DbSet<Varosok> Get()
        {
            DataBaseContext app = new DataBaseContext();
            return app.Varosok;
            
        }

        // GET api/<CityController>/5
        [HttpGet("{id}")]
        public List<Varosok> Get(int id)
        {
            DataBaseContext app = new DataBaseContext();
            return app.Varosok.Where(x=>x.ID == id).ToList();
        }

        // POST api/<CityController>
        [HttpPost]
        public void Post([FromBody] Varosok value)
        {
            DataBaseContext app = new DataBaseContext();
            app.Varosok.Add(value);
            app.SaveChanges();
            
        }

        // PUT api/<CityController>/5
        [HttpPut("{id}")]
        public void Put(uint id, [FromBody] Varosok value)
        {
            DataBaseContext app = new DataBaseContext();
            var find = app.Varosok.Find(id);
            find.VarosNeve = value.VarosNeve;
            find.Nepesseg = value.Nepesseg;
            find.RepuloJaratok = value.RepuloJaratok;
            app.SaveChanges();
        }

        // DELETE api/<CityController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            DataBaseContext app = new DataBaseContext();
            Varosok indexData = app.Varosok.Where(x => x.ID == id).ToList()[0];
            app.Varosok.Remove(indexData);
            app.SaveChanges();
        }
    }
}
