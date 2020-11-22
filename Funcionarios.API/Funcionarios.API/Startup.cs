using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Funcionarios.API.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Funcionarios.API {
    public class Startup {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services) {

            // Usando MVC no projeto
            services.AddMvc();
            // Injeção de Dependência: Quando IFuncionarioRepository, atribuir FuncionarioRepositoryJson; 
            services.AddSingleton<IFuncionarioRepository, FuncionarioRepositoryJson>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env) {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            }

            /*
                A segurança do navegador impede que uma página da Web faça solicitações para um domínio diferente daquele 
                que servia a página da Web. Essa restrição é chamada de política de mesma origem. 
                Esses métodos permitem!
             */
            app.UseCors(config => {
                config.AllowAnyHeader();
                config.AllowAnyMethod();
                config.AllowAnyOrigin();
            });

            app.UseMvc();
        }
    }
}
