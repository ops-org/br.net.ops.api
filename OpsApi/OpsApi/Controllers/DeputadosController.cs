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
using System.Globalization;

namespace OpsApi.Controllers
{
    public class DeputadosController : ApiController
    {
        private AuditoriaOps db = new AuditoriaOps();

        // GET: api/Deputados
        public IQueryable<DeputadoDTO> GetDeputados()
        {
            IQueryable deputados = db.cf_deputado;
            List<DeputadoDTO> deputadosDTO = new List<DeputadoDTO>();
            
            foreach (cf_deputado deputado in deputados)
            {
                deputadosDTO.Add(DeputadoDTO.GeraDTO(deputado));
            }
            db.Dispose();
            return deputadosDTO.AsQueryable();
        }

        // GET: api/Deputados/5
        [ResponseType(typeof(DeputadoDTO))]
        public async Task<IHttpActionResult> GetDeputadoByCarteira(int carteira)
        {
            cf_deputado deputado = await db.cf_deputado.Where(b => b.matricula == carteira).FirstOrDefaultAsync();
            if (deputado == null)
            {
                return NotFound();
            }

            return Ok(DeputadoDTO.GeraDTO(deputado));
        }

        // GET: api/Deputados/5
        [ResponseType(typeof(DeputadoDTO))]
        public async Task<IHttpActionResult> GetDeputadoByIdCadastro(int idCadastro)
        {
            cf_deputado deputado = await db.cf_deputado.Where(b => b.id_cadastro == idCadastro).FirstOrDefaultAsync();
            if (deputado == null)
            {
                return NotFound();
            }

            return Ok(DeputadoDTO.GeraDTO(deputado));
        }

        // GET: api/Deputados/5
        [ResponseType(typeof(DeputadoDTO))]
        public async Task<IHttpActionResult> GetDeputadoByIdParlamentar(int idParlamentar)
        {
            cf_deputado deputado = await db.cf_deputado.Where(b => b.id_parlamentar == idParlamentar).FirstOrDefaultAsync();
            if (deputado == null)
            {
                return NotFound();
            }

            return Ok(DeputadoDTO.GeraDTO(deputado));
        }

        // GET: api/Deputados/5
        
        public IQueryable<DeputadoDTO> GetDeputadosByIdPartido(int partido)
        {
            IQueryable deputados = db.cf_deputado.Where(b => b.id_partido == partido);
            List<DeputadoDTO> deputadosDTO = new List<DeputadoDTO>();

            foreach (cf_deputado deputado in deputados)
            {
                deputadosDTO.Add(DeputadoDTO.GeraDTO(deputado));
            }
            db.Dispose();
            return deputadosDTO.AsQueryable();
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DeputadoExists(int id)
        {
            return db.cf_deputado.Count(e => e.id == id) > 0;
        }
    }
}