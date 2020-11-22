using Funcionarios.API.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Funcionarios.API.Repositories {
    public class FuncionarioRepositoryJson : IFuncionarioRepository {
        public void Adicionar(Funcionario f) {
            IList<Funcionario> funcionarios = Listar().ToList();
            funcionarios.Add(f);
            SalvarFuncionarioArquivo(funcionarios);
        }

        public void Alterar(Funcionario f) {
            List<Funcionario> funcionarios = Listar().ToList();

            int indice = funcionarios.FindIndex(fun => fun.Id == f.Id);

            funcionarios[indice] = f;

            SalvarFuncionarioArquivo(funcionarios);
        }

        public IEnumerable<Funcionario> Listar() {
            IEnumerable<Funcionario> funcionarios;

            using (var fileStream = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + @"\data.json")) {
                funcionarios = JsonConvert.DeserializeObject<IEnumerable<Funcionario>>(fileStream.ReadToEnd());
                fileStream.Close();
                fileStream.Dispose();
            }

            return funcionarios;
        }

        public Funcionario ObterPorId(Guid id) {
            IEnumerable<Funcionario> funcionarios = Listar();
            return funcionarios.FirstOrDefault(f => f.Id == id);
        }

        public void RemoverFuncionario(Funcionario f) {
            List<Funcionario> funcionarios = Listar().ToList();
            funcionarios.RemoveAll(ff => ff.Id == f.Id);

            SalvarFuncionarioArquivo(funcionarios);
        }

        public void SalvarFuncionarioArquivo(IEnumerable<Funcionario> funcionarios) {
            using (var fileStream = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + @"\data.json")) {
                fileStream.Write(JsonConvert.SerializeObject(funcionarios));
                fileStream.Close();
                fileStream.Dispose();
            }
        }
    }
}
