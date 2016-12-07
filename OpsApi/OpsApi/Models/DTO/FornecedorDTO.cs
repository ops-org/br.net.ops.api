using System;

namespace OpsApi.Models.DTO
{
    public class FornecedorDTO
    {
        public long Id { get; set; }
        public string CnpjCpf { get; set; }
        public string Nome { get; set; }
        public bool Doador { get; set; }
        
        //Navigation properties
        public estado Estado { get; set; }
        public fornecedor_info InfoFornecedor { get; set; }

        public static FornecedorDTO GeraDTO(fornecedor fornecedor)
        {
            using (AuditoriaOps db = new AuditoriaOps())
            {
                if (fornecedor != null)
                {
                    return new FornecedorDTO
                    {
                        Nome = fornecedor.nome,
                        Id = fornecedor.id,
                        CnpjCpf = fornecedor.cnpj_cpf,
                        Doador = fornecedor.doador,

                        InfoFornecedor = db.fornecedor_info.Find(fornecedor.id) ?? null,
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