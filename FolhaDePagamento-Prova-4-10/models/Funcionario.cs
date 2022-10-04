using System;
using System.ComponentModel.DataAnnotations;
using API_Folha.Validations;

namespace API.Models
{
    public class Funcionario
    {
        // public Funcionario() => CreatedAt = DateTime.Today;
        public int Id { get; set; }

        [Required (ErrorMessage = "O campo nome é obrogatorio")]
        public string Nome { get; set; }
        
        // [StringLength(
        //     11,
        //     MinimumLength =11,
        //     ErrorMessage = "O campo cpf tem que ter 11 caracteres"
        // )]
        //[CpfEmUso]
        public string Cpf { get; set; }

        [Range(
            0,
            1000,
            ErrorMessage = "Salario deve ser entre 0 e 1000"
        )]
        public double Salario { get; set; }
        
        public string Email { get; set; }
        public string DataDeNascimento { get; set; }
        
        // public DateTime CreatedAt { get; set; }
        public string CreatedAt { get; set; }

    }
}