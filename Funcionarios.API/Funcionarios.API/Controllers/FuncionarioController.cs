using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Funcionarios.API.Models;
using Funcionarios.API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Funcionarios.API.Controllers {
    public class FuncionarioController : Controller {

        private readonly IFuncionarioRepository _repositories;

        public FuncionarioController(IFuncionarioRepository repositories) {
            // Dependência
            _repositories = repositories;
        }

        [HttpGet("v1/funcionarios")]
        public IActionResult ListarFuncionarios() {
            return Ok(_repositories.Listar());
        }

        [HttpPost("v1/funcionarios")]
        public IActionResult AdicionarFuncionario([FromBody] Funcionario f) {
            f.Id = Guid.NewGuid();
            _repositories.Adicionar(f);
            return Ok();
        }

        [HttpPut("v1/funcionarios/{id}")]
        public IActionResult AlterarFuncionario(Guid id, [FromBody] Funcionario f) {
            var fAntigo = _repositories.ObterPorId(id);

            if (fAntigo == null) {
                return NotFound();
            }

            fAntigo.Nome = f.Nome;
            fAntigo.DataNascimento = f.DataNascimento;
            fAntigo.Salario = f.Salario;

            _repositories.Alterar(fAntigo);

            return Ok();
        }

        [HttpGet("v1/funcionarios/{id}")]
        public IActionResult ObterFuncionario(Guid id) {
            var f = _repositories.ObterPorId(id);

            if (f == null) {
                return NotFound();
            }

            return Ok(f);
        }

        [HttpDelete("v1/funcionarios/{id}")]
        public IActionResult RemoverFuncionario(Guid id) {
            var f = _repositories.ObterPorId(id);

            if (f == null) {
                return NotFound();
            }

            _repositories.RemoverFuncionario(f);

            return Ok();
        }

        
    }
}
