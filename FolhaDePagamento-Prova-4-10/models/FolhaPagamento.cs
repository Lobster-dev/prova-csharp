using System;
using System.ComponentModel.DataAnnotations;
using API_Folha.Validations;

namespace API.Models
{
    public class Folha
    {
        //public Folha() => CreatedAt = DateTime.Today;
        public int Id { get; set; }

        public int ValorHora { get; set; }

        public int QuantidadeDeHoras { get; set; }

        public double SalarioBruto { get; set; }

        public double imporstoRenda { get; set; }

        public double impostoInss { get; set; }

        public double impostoFgts { get; set; }

        public double salarioLiquido { get; set; }

        public Funcionario Funcionario { get; set; }

        public String CreatedAt { get; set; }

    }
}