using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Projeto.Presentation.Api.Tests.Contexts
{
    public class TestContext
    {
        //propriedade set/get
        public HttpClient Client { get; set; }

        //atributo para executar os testes
        private TestServer testServer;

        //método construtor -> ctor + 2x[tab]
        //ler o arquivo appsettings.json do projeto API
        public TestContext()
        {
            //lendo o arquivo appsettings.json do projeto API
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            //iniciando o servidor de testes
            testServer = new TestServer(new WebHostBuilder()
                .UseConfiguration(configuration)
                .UseStartup<Presentation.Api.Startup>());

            //gerar o objeto para executar os testes
            Client = testServer.CreateClient();
        }
    }
}
