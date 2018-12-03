using NUnit.Framework;
using System;

namespace Ano.Bissexto
{
    [TestFixture]
    public class AnoBissextoTests
    {
        private bool anoCategoria;
        private AnoBissexto anoEscolhido;

        [OneTimeSetUp]
        public void InicioTestesAno()
        {
            Console.WriteLine("Iniciando testes ANO . . .");
        }

        [SetUp]
        public void CriaAnoEscolhido()
        {
            this.anoEscolhido = new AnoBissexto();
        }

        [Test]
        [Category("Ano")]
        public void DeveReconhecerAnoNaoBissexto()
        {
            anoCategoria = anoEscolhido.EhBissexto(2010);

            Assert.AreEqual(false, anoCategoria);
        }

        [Test]
        [Category("Ano")]
        public void DeveReconhecerAnoBissextoPelaRegra4Em4AnosSomente()
        {
            anoCategoria = anoEscolhido.EhBissexto(2008);

            Assert.AreEqual(true, anoCategoria);
        }

        [Test]
        [Category("Ano")]
        public void DeveReconhecerAnoNaoBissextoPelaRegra100Em100AnosSomente()
        {
            anoCategoria = anoEscolhido.EhBissexto(2100);

            Assert.AreEqual(false, anoCategoria);
        }


        [Test]
        [Category("Ano")]
        public void DeveReconhecerAnoBissextoPelaRegra4Em4AnosE400Em400AnosSomente()
        {
            anoCategoria = anoEscolhido.EhBissexto(2400);

            Assert.AreEqual(true, anoCategoria);
        }

        [OneTimeTearDown]
        public void TerminoTestesAno()
        {
            Console.WriteLine("Terminando testes ANO . . .");
        }

    }
}
