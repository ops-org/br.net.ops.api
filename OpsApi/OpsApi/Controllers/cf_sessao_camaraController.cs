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
    public class cf_sessao_camaraController : ApiController
    {
        private opsauditoriaEntities db = new opsauditoriaEntities();

        // GET: api/cf_sessao_camara
        public IQueryable<cf_sessao_camara> Getcf_sessao_camara()
        {
            return db.cf_sessao_camara;
        }

        // GET: api/cf_sessao_camara/5
        [ResponseType(typeof(cf_sessao_camara))]
        public async Task<IHttpActionResult> Getcf_sessao_camara(int id)
        {
            cf_sessao_camara cf_sessao_camara = await db.cf_sessao_camara.FindAsync(id);
            if (cf_sessao_camara == null)
            {
                return NotFound();
            }

            return Ok(cf_sessao_camara);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool cf_sessao_camaraExists(int id)
        {
            return db.cf_sessao_camara.Count(e => e.idSessao == id) > 0;
        }
    }
}