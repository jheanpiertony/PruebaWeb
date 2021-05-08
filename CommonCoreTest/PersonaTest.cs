using CommonCore.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CommonCoreTest
{
    [TestClass]
    public class PersonaTest
    {
        private string esSordo;
        private string todoBien;
        private string esMudo;

        [TestInitialize]
        public void Inicializar()
        {
            esMudo = "Se comunica con señas";
            esSordo = "Lee los labios";
            todoBien = "Todo bien";
        }

        [TestMethod]
        public void PruebaCuandoLaPersonaEsMudaHablarTest()
        {
            //Prepración -- Arrange (Arreglar, Organizar, Ordenar)
            var persona = new Persona(true, false);

            //Prueba -- Act (Actuar, Acción)
            var resultado = persona.Hablar();

            //Verifiación -- Assert (Afirmar, Asegurar, Hacer valer)
            Assert.AreEqual(resultado, esMudo);

        }
        [TestMethod]
        public void PruebaCuandoLaPersonaNoMudaHablarTest()
        {
            //Prepración -- Arrange (Arreglar, Organizar, Ordenar)
            var a = new Persona(false, false);
            
            //Prueba -- Act (Actuar, Acción)
            var b = a.Hablar();
            
            //Verifiación -- Assert (Afirmar, Asegurar, Hacer valer)
            Assert.AreEqual(b, todoBien);


        }
    }
}
