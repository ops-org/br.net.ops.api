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
            return presencas.Where(p => p.sessao.dataSessao >= dataIn && p.sessao.dataSessao <= dataFi).AsQueryable();
        }

        public double GetPercentualPresenca(int carteiraParlamentar, int leg = 0)
        {
            float perpresenca = 0;
            if (leg == 0)
            {
                leg = db.cf_presenca_deputado.Max(x => x.legislatura);
            }
            IQueryable<sbyte> presencas = from p in db.cf_presenca_deputado.Where(c => c.carteiraParlamentar == carteiraParlamentar)
                               select p.presenca;
            foreach(var i in presencas)
            {
                if (i == 1) perpresenca++;
            }
            double percentual = (perpresenca / presencas.Count()) * 100;
            return percentual;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool presencaExists(int id)
        {
            return db.cf_presenca_deputado.Count(e => e.idpresenca_deputado == id) > 0;
        }
    }
}