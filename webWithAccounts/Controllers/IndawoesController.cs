using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Spatial;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using webWithAccounts.Models;

namespace Ziwava.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [Authorize]
    public class IndawoesController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Indawoes
        public List<Indawo> GetIndawoes(string userLocation, string distance, string vibe, string filter)
        {
            if (userLocation.Split(',')[0] == "undefined") {
                return null;
            }
            var lon = userLocation.Split(',')[0];
            var lat = userLocation.Split(',')[1];
            var vibes = new List<string>() {"Chilled","Club","Outdoor"};
            var filters = new List<string>() { "distance", "rating", "damage" };
            var locations = new List<Indawo>();
            var rnd = new Random();
            if (!string.IsNullOrEmpty(vibe) && vibe != "All" && vibes.Contains(vibe))
            {
                locations = db.Indawoes.Where(x => x.type == vibe).ToList();
            }
            else
            {
                locations = db.Indawoes.ToList().OrderBy(x => rnd.Next()).ToList();
            }
            var listOfIndawoes = Helper.GetNearByLocations(lat, lon, Convert.ToInt32(distance), locations); // TODO: Use distance to narrow search
            //var listOfIndawoes = LoadJson(@"C:\Users\Siya\Desktop\Indawo.json");
            
            foreach (var item in listOfIndawoes) {
                item.images = db.Images.Where(x => x.indawoId == item.id).ToList();
                item.events = db.Events.Where(x => x.indawoId == item.id).ToList();
            }


            if (!string.IsNullOrEmpty(filter) && filter != "None" && filters.Contains(filter)) {
                if (filter == "distance")
                    listOfIndawoes = listOfIndawoes.OrderBy(x => x.distance).ToList();
                else if (filter == "rating")
                    listOfIndawoes = listOfIndawoes.OrderByDescending(x => x.rating).ToList();
                else if (filter == "damage")
                    listOfIndawoes = listOfIndawoes.OrderBy(x => x.entranceFee).ToList();
            }
            
            return listOfIndawoes;
        }


        public List<Indawo> LoadJson(string path)
        {
            using (StreamReader r = new StreamReader(path))
            {
                string json = r.ReadToEnd();
                List<Indawo> items = JsonConvert.DeserializeObject<List<Indawo>>(json);
                return items;
            }
        }

        // GET: api/Indawoes/5
        [ResponseType(typeof(Indawo))]
        public IHttpActionResult GetIndawo(int id)
        {
            Indawo indawo = db.Indawoes.Find(id);
            //Indawo indawo = LoadJson(@"C:\Users\sibongisenib\Documents\ImportantRecentProjects\listOfIndawoes.json").First(x => x.id == id);
            if (indawo == null)
            {
                return NotFound();
            }

            return Ok(indawo);
        }

        // PUT: api/Indawoes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutIndawo(int id, Indawo indawo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != indawo.id)
            {
                return BadRequest();
            }

            db.Entry(indawo).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IndawoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return StatusCode(HttpStatusCode.NoContent);
        }

        private List<Indawo> getPlacesWithInDistance(string userLocation, List<Indawo> listOfIndawo, string distance)
        {
            throw new NotImplementedException();
        }
        private List<Indawo> getIndawoWithIn50k(string userLocation)
        {
            //Using only userLocation return a list of places with in 50K of location
            throw new NotImplementedException();
        }

        // DELETE: api/Indawoes/5
        [ResponseType(typeof(Indawo))]
        public IHttpActionResult DeleteIndawo(int id)
        {
            Indawo indawo = db.Indawoes.Find(id);
            if (indawo == null)
            {
                return NotFound();
            }

            db.Indawoes.Remove(indawo);
            db.SaveChanges();

            return Ok(indawo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool IndawoExists(int id)
        {
            return db.Indawoes.Count(e => e.id == id) > 0;
        }
    }
}