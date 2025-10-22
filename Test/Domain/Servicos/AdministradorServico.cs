using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MINIMALAPI.Dominio.Entidades;
using MINIMALAPI.Dominio.Servicos;
using MINIMALAPI.Infraestrutura.Db;

namespace Test.Domain.Servicos
{
    [TestClass]
    public class AdministradorServicoTest
    {
        private DbContexto CriarContextoDeTeste()
        {
            var assemblyPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var path = Path.GetFullPath(Path.Combine(assemblyPath ?? "", "..", "..", ".."));

            var builder = new ConfigurationBuilder()
                .SetBasePath(path ?? Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables();

            var configuration = builder.Build();

            return new DbContexto(configuration);
        }

        [TestMethod]
        [DoNotParallelize]
        public void TestandoSalvarAdministrador()
        {
            var contexto = CriarContextoDeTeste();
            contexto.Database.ExecuteSqlRaw("TRUNCATE TABLE Administradores;");

            var adm = new Administrador();
            adm.Email = "teste@test.com";
            adm.Senha = "teste";
            adm.Perfil = "adm";

            var servico = new AdministradorServico(contexto);


            servico.Incluir(adm);

            Assert.AreEqual(1, servico.Todos(1).Count());

        }

        [TestMethod]
        [DoNotParallelize]
        public void TestandoBuscarPorIdAdministrador()
        {
            var contexto = CriarContextoDeTeste();
            contexto.Database.ExecuteSqlRaw("TRUNCATE TABLE Administradores;");

            var adm = new Administrador();
            adm.Email = "teste@test.com";
            adm.Senha = "teste";
            adm.Perfil = "adm";

            var servico = new AdministradorServico(contexto);


            servico.Incluir(adm);
            var admDoBanco = servico.BuscarPorId(adm.Id);
            if (admDoBanco != null)
            {
                Assert.AreEqual(1, admDoBanco.Id);
            }
        }

        [TestMethod]
        [DoNotParallelize]
        public void TestandoTodosAdministrador()
        {
            var contexto = CriarContextoDeTeste();
            contexto.Database.ExecuteSqlRaw("TRUNCATE TABLE Administradores;");

            var adm = new Administrador();
            adm.Email = "teste@test.com";
            adm.Senha = "teste";
            adm.Perfil = "adm";

            var servico = new AdministradorServico(contexto);

            servico.Incluir(adm);
            var admLista = servico.Todos(1);

            Assert.AreEqual(1, admLista.Count());

        }
            



        
    }
}