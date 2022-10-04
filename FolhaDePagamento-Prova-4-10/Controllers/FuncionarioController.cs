using Microsoft.AspNetCore.Mvc;
using System;
using API.Models;
using System.Collections.Generic;
using System.Linq;

namespace API.Controllers
{
    [ApiController]
    [Route("api/v1/employee")]

    public class FuncionarioController : ControllerBase
    {

        private static List<Funcionario> funcionarios = new List<Funcionario>();
        private DataContext _context;

        public FuncionarioController(DataContext context) => _context = context;

        // GET: /api/v1/Employe/listar
        [HttpGet]
        [Route("listar")]
        public IActionResult Listar() => Ok(_context.funcionarios.ToList());
        
        // POST: /api/v1/Employe/create
        [HttpPost]
        [Route("create")]
        public IActionResult Cadastrar([FromBody]Funcionario funcionario)
        {
            //funcionarios.Add(funcionario);
            _context.funcionarios.Add(funcionario);
            _context.SaveChanges();
            return Created("", funcionario); //201  
        }

        // GET: /api/v1/Employe/find/cpf
        [HttpGet]
        [Route("find/{cpf}")]
        public IActionResult find([FromRoute]String cpf)
        {
            Funcionario funcionario = _context.funcionarios.FirstOrDefault(
                    f => f.Cpf.Equals(cpf)
                );
            return funcionario != null ? Ok(funcionario) : NotFound();
        }

        // DELETE: /api/v1/Employe/delete/cpf
        [HttpDelete]
        [Route("delete/{id}")]
        public IActionResult delete([FromRoute]int id)
        {
            Funcionario funcionario = _context.funcionarios.Find(id);

            if (funcionario != null)
            {
                _context.funcionarios.Remove(funcionario);
                _context.SaveChanges();
                return Ok(funcionario);
            }
            return NotFound();
        }
        
        // PATCH: /api/v1/Employe/change/
        [HttpPatch]
        [Route("change/")]
        public IActionResult changeEmployee([FromBody]Funcionario funcionario)
        {
            _context.funcionarios.Update(funcionario);
            _context.SaveChanges();
            return Ok(funcionario);
        }
    }
}