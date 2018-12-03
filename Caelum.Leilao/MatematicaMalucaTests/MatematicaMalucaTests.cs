using NUnit.Framework;
using System;

namespace Matematica.Maluca
{
    [TestFixture]
    public class MatematicaMalucaTests
    {
        MatematicaMaluca mm;
        int resultado;

        [SetUp]
        public void CriaMatematicaMaluca()
        {
            mm = new MatematicaMaluca();
            this.resultado = 0;

        }

        [Test]
        [Category("Matematica")]
        public void DeveTestarNumeroMaiorQue30()
        {
            resultado = mm.ContaMaluca(60);
            Assert.AreEqual(240, resultado);
        }

        [Test]
        [Category("Matematica")]
        public void DeveTestarNumeroMaiorQue10EMenorQue30()
        {
            resultado = mm.ContaMaluca(25);
            Assert.AreEqual(75, resultado);
        }

        [Test]
        [Category("Matematica")]
        public void DeveTestarNumeroMenorQue10()
        {
            resultado = mm.ContaMaluca(5);
            Assert.AreEqual(10, resultado);
        }
    }
}
