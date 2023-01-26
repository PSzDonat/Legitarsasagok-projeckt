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
    [Route("reservations")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        // GET: api/<ReservationsController>
        [HttpGet]
        public DbSet<Foglalasok> Get()
        {
            DataBaseContext app = new DataBaseContext();
            return app.Foglalasok;

        }

        // GET api/<ReservationsController>/5
        [HttpGet("{id}")]
        public List<Foglalasok> Get(int id)
        {
            DataBaseContext app = new DataBaseContext();
            return app.Foglalasok.Where(x => x.ID == id).ToList();
        }

        // POST api/<ReservationsController>
        [HttpPost]
        public void Post([FromBody] Foglalasok value)
        {
            DataBaseContext app = new DataBaseContext();
            app.Foglalasok.Add(value);
            app.SaveChanges();

        }

        // PUT api/<ReservationsController>/5
        [HttpPut("{id}")]
        public void Put(uint id, [FromBody] Foglalasok value)
        {
            DataBaseContext app = new DataBaseContext();
            var find = app.Foglalasok.Find(id);
            find.Menetrend_ID = value.Menetrend_ID;
            find.JaratDatuma = value.JaratDatuma;
            find.FoglaltHelyek = value.FoglaltHelyek;
            find.FoglalasokOsszege = value.FoglalasokOsszege;
            find.Menetrend = value.Menetrend;

            app.SaveChanges();
        }

        // DELETE api/<ReservationsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            DataBaseContext app = new DataBaseContext();
            Foglalasok indexData = app.Foglalasok.Where(x => x.ID == id).ToList()[0];
            app.Foglalasok.Remove(indexData);
            app.SaveChanges();
        }
    }
}
