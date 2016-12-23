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
    public class SessoesController : ApiController
    {
        private AuditoriaOps db = new AuditoriaOps();

        public IQueryable<cf_sessao_camara> GetSessoes()
        {
            return db.cf_sessao_camara;
        }

        [ResponseType(typeof(List<cf_sessao_camara>))]
        public async Task<IHttpActionResult> GetSessoesLegislatura(int leg)
        {
            List<cf_sessao_camara> sessoes = await (from b in db.cf_sessao_camara.Where(d => d.legislatura == leg)
                                                select b).ToListAsync();
            if (sessoes.Count == 0)
            {
                return NotFound();
            }

            return Ok(sessoes);
        }

        [ResponseType(typeof(List<cf_sessao_camara>))]
        public async Task<IHttpActionResult> GetSessoesDia(DateTime dia)
        {
            List<cf_sessao_camara> sessoes = await (from b in db.cf_sessao_camara.Where(d => d.dataSessao == dia)
                                                    select b).ToListAsync();
            if (sessoes.Count == 0)
            {
                return NotFound();
            }

            return Ok(sessoes);
        }

        [ResponseType(typeof(List<cf_sessao_camara>))]
        public async Task<IHttpActionResult> GetSessoesPeriodo(DateTime dataIn, DateTime dataFi)
        {
            List<cf_sessao_camara> sessoes = await (from b in db.cf_sessao_camara.Where(d => d.dataSessao >= dataIn && d.dataSessao <= dataFi)
                                                    select b).ToListAsync();
            if (sessoes.Count == 0)
            {
                return NotFound();
            }

            return Ok(sessoes);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool sessaoExists(int id)
        {
            return db.cf_sessao_camara.Count(e => e.idSessao == id) > 0;
        }
    }
}