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
    public class DespesasController : ApiController
    {
        private AuditoriaOps db = new AuditoriaOps();

        // GET: api/Despesas
        public IQueryable<DespesaDTO> GetDespesas()
        {
            List<DespesaDTO> despesas = new List<DespesaDTO>();
            foreach (var despesa in db.cf_despesa)
            {
                despesas.Add(DespesaDTO.GeraDTO(despesa));
            }
            return despesas.AsQueryable();
        }

        // GET: api/Despesas/5
        [ResponseType(typeof(DespesaDTO))]
        public async Task<IHttpActionResult> GetDespesaById(decimal id)
        {
            cf_despesa despesa = await db.cf_despesa.Where(b => b.id == id).FirstOrDefaultAsync();
            if (despesa == null)
            {
                return NotFound();
            }

            return Ok(DespesaDTO.GeraDTO(despesa));
        }

        // GET: api/Despesas/5
        [ResponseType(typeof(DespesaDTO))]
        public async Task<IHttpActionResult> GetDespesaByIdDocumento(decimal idDocumento)
        {
            cf_despesa despesa = await db.cf_despesa.Where(b => b.id_documento == idDocumento).FirstOrDefaultAsync();
            if (despesa == null)
            {
                return NotFound();
            }

            return Ok(DespesaDTO.GeraDTO(despesa));
        }

        //GET: api/Despesas/5
        [ResponseType(typeof(DespesaDTO))]
        public async Task<IHttpActionResult> GetDespesaByIdDeputado(int idDeputado)
        {
            List<DespesaDTO> despesas = new List<DespesaDTO>();
            foreach (var despesa in await db.cf_despesa.Where(b => b.id_cf_deputado == idDeputado).ToListAsync())
            {
                despesas.Add(DespesaDTO.GeraDTO(despesa));
            }
            if (despesas.Count == 0)
            {
                return NotFound();
            }
            return Ok(despesas);
        }

        // GET: api/Despesas/?id=1772&dataInicial=02/05/2015&dataFinal=30/05/2015
        [ResponseType(typeof(DespesaDTO))]
        public async Task<IHttpActionResult> GetDespesaDeputadoByPeriodo(int idDeputado, DateTime dataI, DateTime dataF)
        {
            List<DespesaDTO> despesas = new List<DespesaDTO>();          
            foreach (var despesa in await db.cf_despesa.Where(b => (b.id_cf_deputado == idDeputado && (b.data_emissao >= dataI && b.data_emissao < dataF))).ToListAsync())                                                              
            {
                despesas.Add(DespesaDTO.GeraDTO(despesa));
            }
            if (despesas.Count == 0)
            {
                return NotFound();
            }
            return Ok(despesas);
        }

        // GET: api/Despesas/?dataInicial=yyyy/MM/dd&dataFinal=yyyy/MM/dd
        [ResponseType(typeof(DespesaDTO))]
        public async Task<IHttpActionResult> GetDespesaByPeriodo(DateTime dataI, DateTime dataF)
        {
                List<DespesaDTO> despesas = new List<DespesaDTO>();
                foreach (var despesa in await db.cf_despesa.Where(b => b.data_emissao >= dataI && b.data_emissao < dataF).ToListAsync())
                {
                    despesas.Add(DespesaDTO.GeraDTO(despesa));
                }
                if (despesas.Count == 0)
                {
                    return NotFound();
                }
                return Ok(despesas); 
        }

        // GET: api/Despesas/5
        [ResponseType(typeof(DespesaDTO))]
        public async Task<IHttpActionResult> GetDespesaByTipo(int tipo)
        {
            List<DespesaDTO> despesas = new List<DespesaDTO>();
            foreach (var despesa in await db.cf_despesa.Where(b => b.id_cf_despesa_tipo == tipo).ToListAsync())
            {
                despesas.Add(DespesaDTO.GeraDTO(despesa));
            }
            if (despesas.Count == 0)
            {
                return NotFound();
            }
            return Ok(despesas);
        }

        // GET: api/Despesas/5
        [ResponseType(typeof(DespesaDTO))]
        public async Task<IHttpActionResult> GetDespesaDeputadoByTipo(int idDeputado, int tipo)
        {
            List<DespesaDTO> despesas = new List<DespesaDTO>();
            foreach (var despesa in await db.cf_despesa.Where(b => b.id_cf_despesa_tipo == tipo && b.id_cf_deputado == idDeputado).ToListAsync())
            {
                despesas.Add(DespesaDTO.GeraDTO(despesa));
            }
            if (despesas.Count == 0)
            {
                return NotFound();
            }
            return Ok(despesas);
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