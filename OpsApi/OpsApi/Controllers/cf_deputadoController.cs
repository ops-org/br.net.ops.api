using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using OpsApi.Models;

namespace OpsApi.Controllers
{
    public class cf_deputadoController : ApiController
    {
        private opsauditoriaEntities db = new opsauditoriaEntities();

        // GET: api/cf_deputado
        public IQueryable<cf_deputado> Getcf_deputado()
        {
            return db.cf_deputado;
        }

        // GET: api/cf_deputado/5
        [ResponseType(typeof(cf_deputado))]
        public async Task<IHttpActionResult> Getcf_deputado(int id)
        {
            cf_deputado cf_deputado = await db.cf_deputado.FindAsync(id);
            if (cf_deputado == null)
            {
                return NotFound();
            }

            return Ok(cf_deputado);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool cf_deputadoExists(int id)
        {
            return db.cf_deputado.Count(e => e.id == id) > 0;
        }
    }
}