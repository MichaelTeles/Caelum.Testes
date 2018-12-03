using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caelum.Leilao
{
    [TestFixture]
    public class AvaliadorTest
    {
        private Avaliador leiloeiro;
        private Usuario joao;
        private Usuario jose;
        private Usuario maria;

        [OneTimeSetUp]
        public void TestandoBeforeClass()
        {
            Console.WriteLine("test fixture setup");
        }

        [SetUp]
        public void CriaAvaliador()
        {
            this.leiloeiro = new Avaliador();
            this.joao = new Usuario("Joao");
            this.jose = new Usuario("Jose");
            this.maria = new Usuario("Maria");
        }

        [Test]
        [Category("Leilão")]
        public void DeveEntenderLancesEmOrdemCrescente()
        {
            Leilao leilao = new CriadorDeLeilao().Para("Playstation 3 Novo")
                .Lance(maria, 250.0)
                .Lance(joao, 300.0)
                .Lance(jose, 400.0)
                .Constroi();

            leiloeiro.Avalia(leilao);

            Assert.AreEqual(400, leiloeiro.MaiorLance, 0.0001);
            Assert.AreEqual(250, leiloeiro.MenorLance, 0.0001);
        }

        [Test]
        [Category("Leilão")]
        public void DeveCalcularAMedia()
        {
            Leilao leilao = new CriadorDeLeilao().Para("Playstation 3 Novo")
                .Lance(maria, 300.0)
                .Lance(joao, 400.0)
                .Lance(jose, 500.0)
                .Constroi();

            leiloeiro.Avalia(leilao);

            Assert.AreEqual(400, leiloeiro.ValorMedio, 0.0001);
        }

        [Test]
        [Category("Leilão")]
        public void DeveEntenderLeilaoComApenasUmLance()
        {
            Leilao leilao = new CriadorDeLeilao().Para("Playstation 3 Novo")
                .Lance(joao, 1000.0)
                .Constroi();
            
            leiloeiro.Avalia(leilao);

            Assert.AreEqual(1000, leiloeiro.MaiorLance, 0.0001);
            Assert.AreEqual(1000, leiloeiro.MenorLance, 0.0001);
        }

        [Test]
        [Category("Leilão")]
        public void DeveEncontrarOsTresMaioresLances()
        {
            Leilao leilao = new CriadorDeLeilao().Para("Playstation 3 Novo")
                .Lance(maria, 200.0)
                .Lance(joao, 300.0)
                .Lance(maria, 400.0)
                .Constroi();
            
            leiloeiro.Avalia(leilao);

            var maiores = leiloeiro.TresMaiores;

            Assert.AreEqual(3, maiores.Count);
            Assert.AreEqual(400, maiores[0].Valor, 0.0001);
            Assert.AreEqual(300, maiores[1].Valor, 0.0001);
            Assert.AreEqual(200, maiores[2].Valor, 0.0001);
        }

        [Test]
        [Category("Leilão")]
        public void DeveEntenderLancesEmOrdemRandomica()
        {
            Leilao leilao = new CriadorDeLeilao().Para("Playstation 3 Novo")
                .Lance(joao, 250.0)
                .Lance(maria, 450.0)
                .Lance(jose, 120.0)
                .Lance(maria, 700.0)
                .Lance(joao, 630.0)
                .Lance(jose, 230.0)
                .Constroi();

            leiloeiro.Avalia(leilao);

            Assert.AreEqual(700, leiloeiro.MaiorLance, 0.0001);
            Assert.AreEqual(120, leiloeiro.MenorLance, 0.0001);            
        }

        [Test]
        [Category("Leilão")]
        public void DeveEntenderLancesEmOrdemDecrescente()
        {            
            Leilao leilao = new CriadorDeLeilao().Para("Playstation 3 Novo")
                .Lance(maria, 400.0)
                .Lance(joao, 300.0)
                .Lance(jose, 200.0)
                .Lance(maria, 100.0)
                .Constroi();

            leiloeiro.Avalia(leilao);

            Assert.AreEqual(400, leiloeiro.MaiorLance, 0.0001);
            Assert.AreEqual(100, leiloeiro.MenorLance, 0.0001);
        }

        [Test]
        [Category("Leilão")]
        public void DeveEncontrarOsTresMaioresLancesCom4Lances()
        {
            Leilao leilao = new CriadorDeLeilao().Para("Playstation 3 Novo")
                .Lance(maria, 600.0)
                .Lance(joao, 200.0)
                .Lance(maria, 500.0)
                .Lance(maria, 100.0)
                .Constroi();
                        
            leiloeiro.Avalia(leilao);

            var maiores = leiloeiro.TresMaiores;

            Assert.AreEqual(3, maiores.Count);
            Assert.AreEqual(600, maiores[0].Valor, 0.0001);
            Assert.AreEqual(500, maiores[1].Valor, 0.0001);
            Assert.AreEqual(200, maiores[2].Valor, 0.0001);
        }

        [Test]
        [Category("Leilão")]
        public void DeveDevolverTodosLancesCasoNaoHajaNoMinimo3()
        {
            Leilao leilao = new CriadorDeLeilao().Para("Playstation 3 Novo")
                .Lance(joao, 800.0)
                .Lance(maria, 400.0)
                .Constroi();
            
            leiloeiro.Avalia(leilao);

            var maiores = leiloeiro.TresMaiores;

            Assert.AreEqual(2, maiores.Count);
            Assert.AreEqual(800, maiores[0].Valor, 0.0001);
            Assert.AreEqual(400, maiores[1].Valor, 0.0001);
        }

        //Teste falhará pq tratou com try/catch
        [Test]
        [Category("Leilão")]
        public void DeveDevolverListaVaziaCasoNaoHajaLances()
        {
            Leilao leilao = new CriadorDeLeilao().Para("Playstation 3 Novo")
                .Constroi();
            
            leiloeiro.Avalia(leilao);

            var maiores = leiloeiro.TresMaiores;

            Assert.AreEqual(0, maiores.Count);
        }

        [OneTimeTearDown]
        public void TestandoAfterClass()
        {
            Console.WriteLine("test fixture tear down");
        }

        [Test]
        [Category("Leilão")]
        public void NaoDeveAvaliarLeiloesSemNenhumLanceDado()
        {
            Leilao leilao = new CriadorDeLeilao().Para("Playstation 3 Novo").Constroi();

            Assert.That(() => leiloeiro.Avalia(leilao), Throws.TypeOf<Exception>());           
        }
    }
}
