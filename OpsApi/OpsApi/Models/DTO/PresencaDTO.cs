using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OpsApi.Models.DTO
{
    public class PresencaDTO
    {
        public int idpresenca_deputado { get; set; }
        public int legislatura { get; set; }
        public int carteiraParlamentar { get; set; }
        public sbyte presenca { get; set; }
        public string justificativa { get; set; }
        public Nullable<sbyte> presencaExterna { get; set; }
        public cf_sessao_camara sessao { get; set; }

        public static PresencaDTO GeraDTO(cf_presenca_deputado pr)
        {
            using (AuditoriaOps db = new AuditoriaOps())
            {
                return new PresencaDTO
                {
                    idpresenca_deputado = pr.idpresenca_deputado,
                    legislatura = pr.legislatura,
                    carteiraParlamentar = pr.carteiraParlamentar,
                    presenca = pr.presenca,
                    justificativa = pr.justificativa,
                    presencaExterna = pr.presencaExterna,
                    sessao = db.cf_sessao_camara.Find(pr.idSessao) ?? null
                };
            }
        }
    }
}