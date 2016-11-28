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
    public class cf_despesaController : ApiController
    {
        private opsauditoriaEntities db = new opsauditoriaEntities();

        // GET: api/cf_despesa
        public IQueryable<cf_despesa> Getcf_despesa()
        {
            return db.cf_despesa;
        }

        // GET: api/cf_despesa/5
        [ResponseType(typeof(cf_despesa))]
        public async Task<IHttpActionResult> Getcf_despesa(decimal id)
        {
            cf_despesa cf_despesa = await db.cf_despesa.FindAsync(id);
            if (cf_despesa == null)
            {
                return NotFound();
            }

            return Ok(cf_despesa);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool cf_despesaExists(decimal id)
        {
            return db.cf_despesa.Count(e => e.id == id) > 0;
        }
    }
}