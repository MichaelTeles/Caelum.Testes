using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Palindromo
{
    [TestFixture]
    public class PalindromoTests
    {
        private Palindromo p;
        bool resultado;

        [SetUp]
        public void CriaPalindromo()
        {
            this.p = new Palindromo();
            this.resultado = false;
        }


        [Test]
        [Category("Palindromo")]
        public void DeveIdentificarPalindromoEFiltrarCaracteresInvalidos()
        {
            resultado = p.EhPalindromo("Socorram - me subi no onibus em Marrocos");
            Assert.IsTrue(resultado);
        }

        [Test]
        [Category("Palindromo")]
        public void DeveIdentificarPalindromo()
        {
            resultado = p.EhPalindromo("Anotaram a data da maratona");

            Assert.IsTrue(resultado);
        }

        [Test]
        [Category("Palindromo")]
        public void DeveIdentificarSeNaoEhPalindromo()
        {
            resultado = p.EhPalindromo("E preciso amar as pessoas como se nao houvese amanha");

            Assert.IsFalse(resultado);
        }
    }
}
