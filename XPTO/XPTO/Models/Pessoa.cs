using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace XPTO.Models
{
    public class Pessoa
    {
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public string Sobrenome { get; set; }

        [Required]
        public int CPF { get; set; }
        public DateTime DataNascimento { get; set; }

        public int Idade { get; set; }
        public bool MaiorDeIdade { get; set; }

    }
}