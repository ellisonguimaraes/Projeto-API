using ConsumindoAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsumindoAPI.Repositories {
    public interface IFuncionarioRepository {
        Task<IEnumerable<Funcionario>> ListarFuncionarios();
        Task Adicionar(Funcionario f);
        Task Alterar(Funcionario f);
        Task<Funcionario> ObterPorId(Guid id);
        Task Remover(Funcionario f);
    }
}
