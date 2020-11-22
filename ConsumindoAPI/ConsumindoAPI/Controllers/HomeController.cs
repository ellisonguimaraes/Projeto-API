using ConsumindoAPI.Models;
using ConsumindoAPI.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsumindoAPI.Controllers {
    public class HomeController : Controller {

        private readonly IFuncionarioRepository _repositories;

        public HomeController(IFuncionarioRepository repositories) {
            //Consumindo Dependência
            _repositories = repositories;
        }

        public async Task<IActionResult> Index() {
            return View(await _repositories.ListarFuncionarios());
        }

        [HttpGet]
        public IActionResult Adicionar() {
            return View("Form");
        }

        [HttpPost]
        public IActionResult Adicionar(Funcionario f) {
            _repositories.Adicionar(f);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Remover(Guid id) {
            Funcionario f = await _repositories.ObterPorId(id);

            if(f == null) {
                return NotFound();
            }
            
            await _repositories.Remover(f);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Editar(Guid id) {
            Funcionario f = await _repositories.ObterPorId(id);

            if (f == null) {
                return NotFound();
            }

            return View("Edit", f);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(Funcionario f) {

            await _repositories.Alterar(f);

            return RedirectToAction("index");
        }
    }
}
