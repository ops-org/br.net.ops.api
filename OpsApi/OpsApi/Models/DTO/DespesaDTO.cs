using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OpsApi.Models.DTO
{
    public class DespesaDTO
    {
        public decimal Id { get; set; }
        public Nullable<decimal> IdDocumento { get; set; }
        public Nullable<long> IdMandato { get; set; }
        public Nullable<long> IdEspecificacao { get; set; }
        public string NomePassageiro { get; set; }
        public string NumeroDocumento { get; set; }
        public int TipoDocumento { get; set; }
        public Nullable<DateTime> DataEmissao { get; set; }
        public Nullable<decimal> ValorDocumento { get; set; }
        public Nullable<decimal> valor_documento { get; set; }
        public Nullable<decimal> ValorGlosa { get; set; }
        public decimal ValorLiquido { get; set; }
        public Nullable<decimal> ValorRestituicao { get; set; }
        public int Mes { get; set; }
        public int Ano { get; set; }
        public long Parcela { get; set; }
        public string TrechoViagem { get; set; }
        public long Lote { get; set; }
        public Nullable<long> Ressarcimento { get; set; }
        public long AnoMes { get; set; }

        //Navigation properties
        public DeputadoDTO Deputado { get; set; }
        public FornecedorDTO Fornecedor { get; set; }
        public cf_despesa_tipo TipoDespesa { get; set; }

        public static DespesaDTO GeraDTO(cf_despesa despesa)
        {
            using (AuditoriaOps db = new AuditoriaOps())
            {
                if (despesa != null)
                {
                    return new DespesaDTO
                    {
                        Id = despesa.id,
                        IdDocumento = despesa.id_documento,
                        IdMandato = despesa.id_cf_mandato,
                        IdEspecificacao = despesa.id_cf_especificacao,
                        NomePassageiro = despesa.nome_passageiro,
                        NumeroDocumento = despesa.numero_documento,
                        TipoDocumento = despesa.tipo_documento,
                        DataEmissao = despesa.data_emissao,
                        ValorDocumento = despesa.valor_documento,
                        ValorLiquido = despesa.valor_liquido,
                        ValorRestituicao = despesa.valor_restituicao,
                        Mes = despesa.mes,
                        Ano = despesa.ano,
                        Parcela = despesa.parcela,
                        TrechoViagem = despesa.trecho_viagem,
                        Lote = despesa.lote,
                        Ressarcimento = despesa.ressarcimento,
                        AnoMes = despesa.ano_mes,

                        Deputado = DeputadoDTO.GeraDTO((from dep in db.cf_deputado.Where(b => b.id == despesa.id_cf_deputado)
                                                        select dep).FirstOrDefault()),
                        TipoDespesa = (from tipo in db.cf_despesa_tipo.Where(b => b.id == despesa.id_cf_despesa_tipo)
                                       select tipo).FirstOrDefault(),
                        Fornecedor = FornecedorDTO.GeraDTO((from forn in db.fornecedor.Where(b => b.id == despesa.id_fornecedor)
                                                            select forn).FirstOrDefault())
                    };
                }
                else
                {
                    return null;
                }   
            }
        }
    }
}