using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OpsApi.Models.DTO
{
    public class DeputadoDTO
    {
        public int Id { get; set; }
        public Nullable<int> IdCadastro { get; set; }
        public Nullable<int> IdParlamentar { get; set; }
        public Nullable<int> CodOrcamento { get; set; }
        public string NomeParlamentar { get; set; }
        public string NomeCivil { get; set; }
        public string Condicao { get; set; }
        public string UrlFoto { get; set; }
        public string Sexo { get; set; }
        public string Gabinete { get; set; }
        public string Fone { get; set; }
        public string Email { get; set; }
        public string Profissao { get; set; }
        public Nullable<DateTime> Nascimento { get; set; }
        public Nullable<DateTime> Falecimento { get; set; }
        public Nullable<int> Matricula { get; set; }
        public Nullable<decimal> ValorTotalCeap { get; set; }
        public Nullable<int> QntSecretarios { get; set; }

        //Navigation properties
        public partido Partido { get; set; }
        public estado Estado { get; set; }

        public static DeputadoDTO GeraDTO(cf_deputado deputado)
        {
            using (AuditoriaOps dbp = new AuditoriaOps())
            {
                if (deputado != null)
                {
                    return new DeputadoDTO
                    {
                        Id = deputado.id,
                        IdCadastro = deputado.id_cadastro,
                        IdParlamentar = deputado.id_parlamentar,
                        CodOrcamento = deputado.cod_orcamento,
                        NomeParlamentar = deputado.nome_parlamentar,
                        NomeCivil = deputado.nome_civil,
                        Condicao = deputado.condicao,
                        UrlFoto = deputado.url_foto,
                        Sexo = deputado.sexo,
                        Gabinete = deputado.gabinete,
                        Fone = deputado.fone,
                        Email = deputado.email,
                        Profissao = deputado.profissao,
                        Nascimento = deputado.nascimento,
                        Falecimento = deputado.falecimento,
                        Matricula = deputado.matricula,
                        ValorTotalCeap = deputado.valor_total_ceap,
                        QntSecretarios = deputado.quantidade_secretarios,

                        Partido = (from par in dbp.partido.Where(b => b.id == deputado.id_partido)
                                   select par).FirstOrDefault(),

                        Estado = (from est in dbp.estado.Where(e => e.id == deputado.id_estado)
                                  select est).FirstOrDefault()
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