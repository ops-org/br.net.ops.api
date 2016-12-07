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
    public class FornecedoresController : ApiController
    {
        private AuditoriaOps db = new AuditoriaOps();

        // GET: api/fornecedors
        public IQueryable<FornecedorDTO> Getfornecedores()
        {
            List<FornecedorDTO> fornecedores = new List<FornecedorDTO>();
            foreach (var Fornecedor in db.fornecedor)
            {
                fornecedores.Add(FornecedorDTO.GeraDTO(Fornecedor));
            }
            return fornecedores.AsQueryable();
        }

        // GET: api/fornecedors/5
        [ResponseType(typeof(FornecedorDTO))]
        public async Task<IHttpActionResult> GetfornecedorById(long id)
        {
            fornecedor fornecedor = await db.fornecedor.FindAsync(id);
            if (fornecedor == null)
            {
                return NotFound();
            }

            return Ok(FornecedorDTO.GeraDTO(fornecedor));
        }

        // GET: api/fornecedors/5
        [ResponseType(typeof(FornecedorDTO))]
        public async Task<IHttpActionResult> GetfornecedorByCpfCnpj(string cpfCnpj)
        {
            fornecedor fornecedor = await db.fornecedor.Where(b => b.cnpj_cpf.EndsWith(cpfCnpj)).FirstOrDefaultAsync();
            if (fornecedor == null)
            {
                return NotFound();
            }

            return Ok(FornecedorDTO.GeraDTO(fornecedor));
        }

        // GET: api/fornecedors/5
        [ResponseType(typeof(FornecedorDTO))]
        public async Task<IHttpActionResult> GetfornecedoresByEstado(int estado)
        {
            string UF;
            var queryEstado = (from es in db.estado.Where(e => e.id == estado)
                  select es.sigla);
            if(queryEstado == null)
            { 
                return NotFound();
            }
            else
            {
                UF = queryEstado.FirstOrDefault();
            }
            
            List<FornecedorDTO> fornDTO = new List<FornecedorDTO>();
            List<fornecedor_info> fornecedoresinfo = await db.fornecedor_info.Where(es => es.estado == UF).ToListAsync();
            foreach(var fornecedorinfo in fornecedoresinfo)
            {
                fornDTO.Add(FornecedorDTO.GeraDTO(await db.fornecedor.Where(i => i.id == fornecedorinfo.id_fornecedor).FirstOrDefaultAsync()));
            }
            if (fornDTO.Count == 0)
            {
                return NotFound();
            }

            return Ok(fornDTO);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool fornecedorExists(long id)
        {
            return db.fornecedor.Count(e => e.id == id) > 0;
        }
    }
}