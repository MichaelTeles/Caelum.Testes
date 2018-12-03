using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caelum.Leilao
{
    [TestFixture]
    public class LanceTests
    {
        [Test]
        [Category("Lance")]
        public void NaoDeveAceitarLanceComValor0()
        {            
            Assert.That(() => new Lance(new Usuario("John Doe"), 0), Throws.TypeOf<ArgumentException>());
        }

        [Test]
        [Category("Lance")]
        public void NaoDeveAceitarLanceComValorNegativo()
        {
            Assert.That(() => new Lance(new Usuario("John Doe"), -10), Throws.TypeOf<ArgumentException>());
        }
    }
}
