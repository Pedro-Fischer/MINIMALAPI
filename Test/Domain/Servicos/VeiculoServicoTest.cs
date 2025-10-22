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
    public class VeiculoServicoTest
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
        public void TestandoSalvarVeiculo()
        {
            var contexto = CriarContextoDeTeste();
            contexto.Database.ExecuteSqlRaw("TRUNCATE TABLE Veiculos;");

            var veiculo = new Veiculo();
            veiculo.Nome = "TesteN";
            veiculo.Marca = "TesteM";
            veiculo.Ano = 2020;

            var servico = new VeiculoServico(contexto);
            servico.Adicionar(veiculo);

            Assert.AreEqual(1, servico.Todos(1).Count());
        }

        [TestMethod]
        [DoNotParallelize]
        public void TestandoBuscarPorIdVeiculo()
        {
            var contexto = CriarContextoDeTeste();
            contexto.Database.ExecuteSqlRaw("TRUNCATE TABLE Veiculos;");

            var veiculo = new Veiculo();
            veiculo.Nome = "TesteN";
            veiculo.Marca = "TesteM";
            veiculo.Ano = 2020;

            var servico = new VeiculoServico(contexto);
            servico.Adicionar(veiculo);
            var veiculoLista = servico.BuscarPorId(1);

            if (veiculoLista != null)
            {
                Assert.AreEqual(1, veiculoLista.Id);
            }
        }

        [TestMethod]
        [DoNotParallelize]
        public void TestandoAtualizarVeiculo()
        {
            var contexto = CriarContextoDeTeste();
            contexto.Database.ExecuteSqlRaw("TRUNCATE TABLE Veiculos;");

            var veiculo = new Veiculo();
            veiculo.Nome = "TesteN";
            veiculo.Marca = "TesteM";
            veiculo.Ano = 2020;

            var servico = new VeiculoServico(contexto);
            servico.Adicionar(veiculo);
            veiculo.Ano = 2021;
            servico.Atualizar(veiculo);

            Assert.AreEqual(2021, veiculo.Ano);
        }

        [TestMethod]
        [DoNotParallelize]
        public void TestandoApagarVeiculo()
        {
            var contexto = CriarContextoDeTeste();
            contexto.Database.ExecuteSqlRaw("TRUNCATE TABLE Veiculos;");

            var veiculo = new Veiculo();
            veiculo.Nome = "TesteN";
            veiculo.Marca = "TesteM";
            veiculo.Ano = 2020;

            var servico = new VeiculoServico(contexto);
            servico.Adicionar(veiculo);
            servico.Apagar(veiculo);

            Assert.AreEqual(0, servico.Todos(1).Count());
        }
        
        [TestMethod]
        [DoNotParallelize]
        public void TestandoTodosAdministrador()
        {
            var contexto = CriarContextoDeTeste();
            contexto.Database.ExecuteSqlRaw("TRUNCATE TABLE Administradores;");

            var veiculo = new Administrador();
            veiculo.Email = "teste@test.com";
            veiculo.Senha = "teste";
            veiculo.Perfil = "adm";

            var servico = new AdministradorServico(contexto);

            servico.Incluir(veiculo);
            var veiculoLista = servico.Todos(1);

            Assert.AreEqual(1, veiculoLista.Count());

        }
    }
}