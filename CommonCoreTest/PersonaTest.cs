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
            esMudo = "Se comunica con se�as";
            esSordo = "Lee los labios";
            todoBien = "Todo bien";
        }

        [TestMethod]
        public void PruebaCuandoLaPersonaEsMudaHablarTest()
        {
            //Prepraci�n -- Arrange (Arreglar, Organizar, Ordenar)
            var persona = new Persona(true, false);

            //Prueba -- Act (Actuar, Acci�n)
            var resultado = persona.Hablar();

            //Verifiaci�n -- Assert (Afirmar, Asegurar, Hacer valer)
            Assert.AreEqual(resultado, esMudo);

        }
        [TestMethod]
        public void PruebaCuandoLaPersonaNoMudaHablarTest()
        {
            //Prepraci�n -- Arrange (Arreglar, Organizar, Ordenar)
            var a = new Persona(false, false);
            
            //Prueba -- Act (Actuar, Acci�n)
            var b = a.Hablar();
            
            //Verifiaci�n -- Assert (Afirmar, Asegurar, Hacer valer)
            Assert.AreEqual(b, todoBien);


        }
    }
}
