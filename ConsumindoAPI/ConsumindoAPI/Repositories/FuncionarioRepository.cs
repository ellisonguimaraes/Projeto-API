using ConsumindoAPI.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;


/**
 * Classe responsável por consumir a API 
 *  - MUDAR URL CASO NECESSÁRIO
**/

namespace ConsumindoAPI.Repositories {
    public class FuncionarioRepository : IFuncionarioRepository {

        private string url = "http://localhost:5005/v1/funcionarios";

        public async Task Adicionar(Funcionario f) {
            using (var http = new HttpClient()) {
                await http.PostAsJsonAsync<Funcionario>(url, f);
            }
        }

        public async Task Alterar(Funcionario f) {
            using (var http = new HttpClient()) {
                await http.PutAsJsonAsync<Funcionario>(url+"/"+f.Id, f);
            }
        }

        public async Task<IEnumerable<Funcionario>> ListarFuncionarios() {

            IEnumerable<Funcionario> funcionarios = null;

            using (var http = new HttpClient()) {
                var response = await http.GetStringAsync(url);
                funcionarios = JsonConvert.DeserializeObject<List<Funcionario>>(response);
            }

            return funcionarios;
        }

        public async Task<Funcionario> ObterPorId(Guid id) {
            Funcionario funcionario;

            using (var http = new HttpClient()) {
                var response = await http.GetStringAsync(url+"/"+id);
                funcionario = JsonConvert.DeserializeObject<Funcionario>(response);
            }

            return funcionario;
        }

        public async Task Remover(Funcionario f) {
            using (var http = new HttpClient()) {
                await http.DeleteAsync(url + "/" + f.Id);
            }
        }
    }
}
