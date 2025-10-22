using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MINIMALAPI.Dominio.Entidades;

namespace Test.Domain.Entidades
{
    [TestClass]
    public class VeiculoTest
    {
        [TestMethod]
        public void TestarGetSetPropriedades()
        {
            //arrange
            var veiculo = new Veiculo();

            //act
            veiculo.Id = 1;
            veiculo.Nome = "TesteNome";
            veiculo.Marca = "TesteMarca";
            veiculo.Ano = 2020;

            //assert
            Assert.AreEqual(1, veiculo.Id);
            Assert.AreEqual("TesteNome", veiculo.Nome);
            Assert.AreEqual("TesteMarca", veiculo.Marca);
            Assert.AreEqual(2020, veiculo.Ano);
        }
    }
}