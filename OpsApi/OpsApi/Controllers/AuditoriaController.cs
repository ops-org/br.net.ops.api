using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.Entity;
using System.Web;
using System.Threading.Tasks;
using System.Web.Http.Description;
using System.Web.Http;
using OpsApi.Models;
using OpsApi.Models.DTO;

namespace OpsApi.Controllers
{
    public class AuditoriaController : ApiController
    {
        private AuditoriaOps db = new AuditoriaOps();
        // GET: Auditoria
        public List<Auditoria> GetAuditoriaByDeputado(int idDeputado, int audit)
        {
            /*Auditoria auditoria = new Auditoria();
            auditoria.Deputado = DeputadoDTO.GeraDTO(db.cf_deputado.Where(b => b.id == idDeputado).FirstOrDefault());*/
            List<Auditoria> lista = null;
            return lista;
        }

        public List<Auditoria> GetAuditoriasDeputado(int idDeputado)
        {
            List<Auditoria> lista = null;
            return lista;
        }
    }
}