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
using OpsApi.Models.DTO;

namespace OpsApi.Controllers
{
    public class PresencasController : ApiController
    {
        private AuditoriaOps db = new AuditoriaOps();

        public IQueryable<PresencaDTO> GetPresencasDeputado(int carteiraParlamentar, int leg = 0)
        {
            if (leg == 0)
            {
                leg = db.cf_presenca_deputado.Max(x => x.legislatura);                    
            }
            List<PresencaDTO> presencas = new List<PresencaDTO>();
            foreach(cf_presenca_deputado presenca in db.cf_presenca_deputado.Where(d => d.carteiraParlamentar == carteiraParlamentar && d.legislatura == leg))
            {
                presencas.Add(PresencaDTO.GeraDTO(presenca));
            }
            return presencas.AsQueryable();
        }

        public IQueryable<PresencaDTO> GetPresencasDeputadoByPeriodo(int carteiraParlamentar, DateTime dataIn, DateTime dataFi, int leg = 0)
        {
            if (leg == 0)
            {
                leg = db.cf_presenca_deputado.Max(x => x.legislatura);
            }
            List<PresencaDTO> presencas = new List<PresencaDTO>();
            foreach (cf_presenca_deputado presenca in db.cf_presenca_deputado.Where(d => d.carteiraParlamentar == carteiraParlamentar))
            {
                presencas.Add(PresencaDTO.GeraDTO(presenca));
            }
            return presencas.Where(p => p.sessao.dataSessao > dataIn && p.sessao.dataSessao <= dataFi).AsQueryable();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool cf_presenca_deputadoExists(int id)
        {
            return db.cf_presenca_deputado.Count(e => e.idpresenca_deputado == id) > 0;
        }
    }
}