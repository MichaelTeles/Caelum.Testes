using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caelum.Leilao
{
    [TestFixture]
    public class LeilaoTests
    {
        private Avaliador leiloeiro;
        private Usuario jobs;
        private Usuario wozniak;
        private Usuario gates;

        [SetUp]
        public void CriaAvaliadorEUsuarios()
        {
            this.leiloeiro = new Avaliador();
            this.jobs = new Usuario("Steve Jobs");
            this.wozniak = new Usuario("Steve Wozniak");
            this.gates = new Usuario("Bill Gates");
        }

        [Test]
        [Category("Leilão 2")]
        public void DeveReceberUmLance()
        {
            Leilao leilao = new CriadorDeLeilao().Para("Mackbook Pro 15").Constroi();
            
            Assert.AreEqual(0, leilao.Lances.Count);

            leilao.Propoe(new Lance(jobs, 2000.0));

            Assert.AreEqual(1, leilao.Lances.Count);
            Assert.AreEqual(2000, leilao.Lances[0].Valor, 0.00001);
        }

        [Test]
        [Category("Leilão 2")]
        public void DeveReceberVariosLances()
        {
            Leilao leilao = new CriadorDeLeilao().Para("Mackbook Pro 15").Constroi();
            
            Assert.AreEqual(0, leilao.Lances.Count);

            leilao.Propoe(new Lance(jobs, 2000.0));
            leilao.Propoe(new Lance(wozniak, 3000.0));
            
            Assert.AreEqual(2, leilao.Lances.Count);
            Assert.AreEqual(2000, leilao.Lances[0].Valor, 0.00001);
            Assert.AreEqual(3000, leilao.Lances[1].Valor, 0.00001);
            Console.WriteLine(wozniak.Nome);
        }

        [Test]
        [Category("Leilão 2")]
        public void NaoDeveAceitarDoisLancesSeguidosDoMesmoUsuario()
        {
            Leilao leilao = new CriadorDeLeilao().Para("Macbook Pro 15")
                .Lance(jobs,2000.0)
                .Lance(jobs, 3000.0)
                .Constroi();
            
            Assert.AreEqual(1, leilao.Lances.Count);
            Assert.AreEqual(2000, leilao.Lances[0].Valor, 0.0001);
        }

        [Test]
        [Category("Leilão 2")]
        public void NaoDeveAceitarMaisDoQue5LancesDeUmMesmoUsuario()
        {
            Leilao leilao = new CriadorDeLeilao().Para("Macbook Pro 15")
                .Lance(jobs, 2000.0)
                .Lance(gates, 3000.0)

                .Lance(jobs, 4000.0)
                .Lance(gates, 5000.0)

                .Lance(jobs, 6000.0)
                .Lance(gates, 7000.0)

                .Lance(jobs, 8000.0)
                .Lance(gates, 9000.0)

                .Lance(jobs, 10000.0)
                .Lance(gates, 11000.0)

                //Deve ser ignorado
                .Lance(jobs, 12000.0)
                .Constroi();

            Assert.AreEqual(10, leilao.Lances.Count);
            var ultimo = leilao.Lances.Count - 1;
            Lance ultimoLance = leilao.Lances[ultimo];

            Assert.AreEqual(11000, ultimoLance.Valor, 0.00001); 
        }

        [Test]
        [Category("Leilão 2")]
        public void DeveDobrarUltimoLancePropostoPeloUsuario()
        {
            Leilao leilao = new CriadorDeLeilao().Para("Macbook Air")
                .Lance(jobs, 2000.0)
                .Lance(wozniak, 1000.0)
                .Constroi();

            leilao.DobraLance(jobs);

            Assert.AreEqual(4000, leilao.Lances[2].Valor, 0.00001);            
        }

        [Test]
        [Category("Leilão 2")]
        public void NaoDeveDobrarCasoNaoHajaLanceAnterior()
        {
            Leilao leilao = new CriadorDeLeilao().Para("Macbook Air")
                .Constroi();

            leilao.DobraLance(jobs);

            Assert.AreEqual(0, leilao.Lances.Count);
        }
    }
}
