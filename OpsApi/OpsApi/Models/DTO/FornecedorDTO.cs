using System;

namespace OpsApi.Models.DTO
{
    public class FornecedorDTO
    {
        public int Id { get; set; }
        public string CnpjCpf { get; set; }
        public string Nome { get; set; }
        public int Doador { get; set; }
        public DateTime ObtidoEm { get; set; }
        public DateTime DataAbertura { get; set; }
        public string NomeFantasia { get; set; }
        public string Logradouro { get; set; }
        public int Numero { get; set; }
        public string Complemento { get; set; }
        public string Cep { get; set; }
        public string Bairro { get; set; }
        public string Municipio { get; set; }
        public string EnderecoEletronico { get; set; }
        public string Telefone { get; set; }
        public string EnteFederativoResponsavel { get; set; }
        public string SituacaoCadastral { get; set; }
        public DateTime DataSituacaoCadastral { get; set; }
        public string MotivoSituacaoCadastral { get; set; }
        public string SituacaoEspecial { get; set; }
        public string DataSituacaoEspecial { get; set; }
        public double CapitalSocial { get; set; }

        //Navigation properties
        public fornecedor_natureza_juridica NaturezaJuridica { get; set; }
        public estado Estado { get; set; }
    }
}