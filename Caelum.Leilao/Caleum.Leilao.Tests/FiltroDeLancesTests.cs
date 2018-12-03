using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caelum.Leilao
{
    [TestFixture]
    public class FiltroDeLancesTests
    {
        private FiltroDeLances filtro;
        private IList<Lance> resultado;

        private Usuario joao;

        [SetUp]
        public void CriaFiltroDeLancesEUsuariosEAvaliador()
        {
            this.filtro = new FiltroDeLances();
            this.joao = new Usuario("Joao");
        }

        [Test]
        [Category("Filtro De Lances")]
        public void DeveSelecionarLancesEntre1000E3000()
        {
            resultado = filtro.Filtra(new List<Lance>()
                {
                new Lance(joao, 2000),
                new Lance(joao, 1000),
                new Lance(joao, 3000),
                new Lance(joao, 800)
            });

            Assert.AreEqual(1, resultado.Count);
            Assert.AreEqual(2000, resultado[0].Valor, 0.00001);
        }

        [Test]
        [Category("Filtro De Lances")]
        public void DeveSelecionarLancesEntre500E700()
        {
            resultado = filtro.Filtra(new List<Lance>()
            {
                new Lance(joao, 600),
                new Lance(joao, 500),
                new Lance(joao, 700),
                new Lance(joao, 800)
            });

            Assert.AreEqual(1, resultado.Count);
            Assert.AreEqual(600, resultado[0].Valor, 0.00001);
        }

        [Test]
        [Category("Filtro De Lances")]
        public void DeveSelecionarLancesMaiorQue5000()
        {
            resultado = filtro.Filtra(new List<Lance>()
            {
                new Lance(joao, 6000),
                new Lance(joao, 800)
            });

            Assert.AreEqual(1, resultado.Count);
            Assert.AreEqual(6000, resultado[0].Valor, 0.00001);
        }

        [Test]
        [Category("Filtro De Lances")]
        public void DeveEliminarMenoresQue5000()
        {
            resultado = filtro.Filtra(new List<Lance>()
            {
                new Lance(joao, 400),
                new Lance(joao, 300)
            });

            Assert.AreEqual(0, resultado.Count);
        }

        [Test]
        [Category("Filtro De Lances")]
        public void DeveEliminarEntre3000E5000()
        {
            resultado = filtro.Filtra(new List<Lance>()
            {
                new Lance(joao, 3500),
                new Lance(joao, 4000)
            });

            Assert.AreEqual(0, resultado.Count);
        }
    }
}
