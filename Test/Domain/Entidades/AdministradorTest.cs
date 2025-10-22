using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MINIMALAPI.Dominio.Entidades;

namespace Test.Domain.Entidades
{
    [TestClass]
    public class AdministradorTest
    {   
        [TestMethod]
        public void TestarGetSetPropriedades()
        {
            //arrange
            var adm = new Administrador();


            //act
            adm.Id = 1;
            adm.Email = "teste@test.com";
            adm.Senha = "teste";
            adm.Perfil = "adm";

            //assert
            Assert.AreEqual(1, adm.Id);
            Assert.AreEqual("teste@test.com", adm.Email);
            Assert.AreEqual("teste", adm.Senha);
            Assert.AreEqual("adm", adm.Perfil);
        }




        
    }
}