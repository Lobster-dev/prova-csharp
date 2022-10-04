using Microsoft.AspNetCore.Mvc;
using System;
using API.Models;
using System.Collections.Generic;
using System.Linq;
using API.Controller;

namespace API.Controllers
{
    [ApiController]
    [Route("api/v1/folha")]

    public class folhaPagamentoController : ControllerBase
    {

        private static List<Folha> folha = new List<Folha>();
        private DataContext _context;
        public CalculaDados _calculaDadosFolha;
    
        public folhaPagamentoController(DataContext context) => _context = context;
        

        // GET: /api/v1/folha/listar
        [HttpGet]
        [Route("listar")]
        public IActionResult Listar() => Ok(_context.folhaPagamentos.ToList());
        
        // POST: /api/v1/folha/create
        [HttpPost]
        [Route("create")]
        public IActionResult Cadastrar([FromBody]Folha folhaPagamentoEnviada) // [FromBody] //int funcionarioId, double ValorHora, int QuantidadeDeHoras
        {
            
            
            double valorHora      = folhaPagamentoEnviada.ValorHora;
            int quantidadeDeHoras = folhaPagamentoEnviada.QuantidadeDeHoras;

            double salarioBruto   = _calculaDadosFolha.calcularSalarioBruto(valorHora,quantidadeDeHoras);
            double valorIR        = _calculaDadosFolha.calculaImporstoDeRenda(salarioBruto);
            double valorInss      = _calculaDadosFolha.calculaInss(salarioBruto);
            double valorFgts      = _calculaDadosFolha.CalculaValorFGTS(salarioBruto);
            double salarioLiquido = _calculaDadosFolha.calculaSalarioLiquido(salarioBruto,valorIR, valorInss);

            folhaPagamentoEnviada.SalarioBruto   = salarioBruto;
            folhaPagamentoEnviada.imporstoRenda  = valorIR;
            folhaPagamentoEnviada.impostoInss    = valorInss;
            folhaPagamentoEnviada.impostoFgts    = valorFgts;
            folhaPagamentoEnviada.salarioLiquido = salarioLiquido;

            _context.folhaPagamentos.Add(folhaPagamentoEnviada); 
            _context.SaveChanges();
            return Created("", folhaPagamentoEnviada); //201  
           
            
        }

        // GET: /api/v1/folha/find/cpf
        [HttpGet]
        [Route("find/{cpf}/{dia}/{mes}/{ano}")]
        public IActionResult find([FromRoute]String cpf, String dia, String mes, String ano)
        {
           Folha folha = _context.folhaPagamentos.FirstOrDefault(
               f => !(!f.Funcionario.Cpf.Equals(cpf) && !f.CreatedAt.Equals(dia+"/"+mes+"/"+ano))
           );
           return folha != null ? Ok(folha) : NotFound();
        }

        //DELETE: /api/v1/folha/delete/cpf
        [HttpGet]
        [Route("filtrar{mes}/{ano}")]
        public IActionResult filter([FromRoute]String mes, String ano)
        {
            return null;
        }

        


    }
}