//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OpsApi.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class fornecedor_info
    {
        public long id_fornecedor { get; set; }
        public string cnpj { get; set; }
        public Nullable<System.DateTime> obtido_em { get; set; }
        public string nome { get; set; }
        public Nullable<System.DateTime> data_de_abertura { get; set; }
        public string nome_fantasia { get; set; }
        public Nullable<int> id_fornecedor_atividade_principal { get; set; }
        public Nullable<int> id_fornecedor_natureza_juridica { get; set; }
        public string logradouro { get; set; }
        public string numero { get; set; }
        public string complemento { get; set; }
        public string cep { get; set; }
        public string bairro { get; set; }
        public string municipio { get; set; }
        public string estado { get; set; }
        public string endereco_eletronico { get; set; }
        public string telefone { get; set; }
        public string ente_federativo_responsavel { get; set; }
        public string situacao_cadastral { get; set; }
        public Nullable<System.DateTime> data_da_situacao_cadastral { get; set; }
        public string motivo_situacao_cadastral { get; set; }
        public string situacao_especial { get; set; }
        public Nullable<System.DateTime> data_situacao_especial { get; set; }
        public Nullable<decimal> capital_social { get; set; }
        public string ip_colaborador { get; set; }
    }
}