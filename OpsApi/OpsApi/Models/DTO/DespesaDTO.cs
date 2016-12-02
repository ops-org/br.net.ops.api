using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OpsApi.Models.DTO
{
    public class DespesaDTO
    {
        public int Id { get; set; }
        public int IdDocumento { get; set; }
        public int IdMandato { get; set; }
        public int IdEspecificacao { get; set; }
        public string NomePassageiro { get; set; }
        public string NumeroDocumento { get; set; }
        public int TipoDocumento { get; set; }
        public DateTime DataEmissao { get; set; }
        public double ValorDocumento { get; set; }
        public double ValorGlosa { get; set; }
        public double ValorLiquido { get; set; }
        public double ValorRestituicao { get; set; }
        public int Mes { get; set; }
        public int Ano { get; set; }
        public int Parcela { get; set; }
        public string TrechoViagem { get; set; }
        public int Lote { get; set; }
        public int Ressarcimento { get; set; }
        public int AnoMes { get; set; }

        //Navigation properties
        public DeputadoDTO Deputado { get; set; }
        public FornecedorDTO Fornecedor { get; set; }
        public cf_despesa_tipo TipoDespesa { get; set; }


    }
}