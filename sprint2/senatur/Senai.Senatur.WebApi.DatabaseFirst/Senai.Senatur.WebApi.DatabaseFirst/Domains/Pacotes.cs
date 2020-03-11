using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Senai.Senatur.WebApi.DatabaseFirst.Domains
{
    public partial class Pacotes
    {
        public int IdPacote { get; set; }
        
        [Required(ErrorMessage = "O nome do pacote é obrigatório")]
        public string NomePacote { get; set; }

        [Required(ErrorMessage = "A descrição do pacote é obrigatória")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "A data de ida do pacote é obrigatória")]
        public DateTime DataIda { get; set; }

        [Required(ErrorMessage = "A data de volta do pacote é obrigatória")]
        public DateTime DataVolta { get; set; }

        [Required(ErrorMessage = "O preço do pacote é obrigatório")]
        public decimal Valor { get; set; }

        [Required(ErrorMessage = "Informe a atividade do pacote")]
        public string Ativo { get; set; }

        [Required(ErrorMessage = "O nome da cidade do pacote é obrigatório")]
        public string NomeCidade { get; set; }
    }
}
