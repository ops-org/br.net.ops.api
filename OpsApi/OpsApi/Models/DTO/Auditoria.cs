using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OpsApi.Models.DTO
{
    public class Auditoria
    {
        public DeputadoDTO Deputado { get; set; }
        public FornecedorDTO Fornecedor { get; set; }
        public List<DespesaDTO> despesas { get; set; }
        public string motivo { get; set; }

    }
}