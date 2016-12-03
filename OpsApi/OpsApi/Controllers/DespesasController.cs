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
    public class DespesasController : ApiController
    {
        private AuditoriaOps db = new AuditoriaOps();

        // GET: api/Despesas
        public IQueryable<cf_despesa> GetDespesas()
        {
            return db.cf_despesa;
        }

        // GET: api/Despesas/5
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

        // PUT: api/Despesas/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Putcf_despesa(decimal id, cf_despesa cf_despesa)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cf_despesa.id)
            {
                return BadRequest();
            }

            db.Entry(cf_despesa).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!cf_despesaExists(id))
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

        // POST: api/Despesas
        [ResponseType(typeof(cf_despesa))]
        public async Task<IHttpActionResult> Postcf_despesa(cf_despesa cf_despesa)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.cf_despesa.Add(cf_despesa);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = cf_despesa.id }, cf_despesa);
        }

        // DELETE: api/Despesas/5
        [ResponseType(typeof(cf_despesa))]
        public async Task<IHttpActionResult> Deletecf_despesa(decimal id)
        {
            cf_despesa cf_despesa = await db.cf_despesa.FindAsync(id);
            if (cf_despesa == null)
            {
                return NotFound();
            }

            db.cf_despesa.Remove(cf_despesa);
            await db.SaveChangesAsync();

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