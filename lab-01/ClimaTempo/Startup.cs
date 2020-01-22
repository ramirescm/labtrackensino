using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ClimaTempo
{
    public class Startup
    {
        /*
         - o ASPNET Core se encarrega de resolver a dependencia
         - usa-se interface para abstrair a implementa��o favorencedo o desacoplamento e troca da implementa��o
         - uma depend�ncia � qualquer objeto exigido por outro objeto.

         fonte : https://docs.microsoft.com/pt-br/aspnet/core/fundamentals/dependency-injection?view=aspnetcore-3.1
        */

        // configura��o � injetada para trabalharmos com confiugura��es na aplica��o
        // voc� quase certamente precisar� acessar isso para configurar seus servi�os, por isso faz sentido
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // adiciona os servi�os necess�rios para usar controladores de API da Web e nada mais
            services.AddControllers();
        }

        // Este m�todo � chamado pelo tempo de execu��o. Use este m�todo para configurar o pipeline de solicita��o HTTP.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // verifica se estamos no ambiente de desenvolvimento
            if (env.IsDevelopment())
            {
                // p�gina de erro no ambiente de desenvolvimento
                app.UseDeveloperExceptionPage();
            }

            // Middleware de redirecionamento de HTTPS para redirecionar solicita��es HTTP para HTTPS.
            app.UseHttpsRedirection();


            // adiciona as configura��es de roteamento ao conteiner de servi�o
            // esse midleware verifica de onde vem e a requisi��o e decide qual endpoint pode executar
            // fonte: https://docs.microsoft.com/pt-br/aspnet/core/fundamentals/routing?view=aspnetcore-3.1
            app.UseRouting();

            app.UseAuthorization();

            //  este midleware � reponsavel por configurar os endpoints e tamb�m por executalos
            // fonte: https://docs.microsoft.com/pt-br/aspnet/core/fundamentals/routing?view=aspnetcore-3.1
            app.UseEndpoints(endpoints =>
            {
                /* 
                 definimos que sera nos requisi��es ser atendidas pelos controllers
                 os controladores da API s�o mapeados chamando endpoints.MapControllers (). 
                 Isso mapeia apenas controladores decorados com atributos de roteamento
                 */
                endpoints.MapControllers();
            });
        }
    }
}
