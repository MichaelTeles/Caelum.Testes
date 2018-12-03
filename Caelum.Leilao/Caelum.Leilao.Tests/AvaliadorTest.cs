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
        [Test]
        [Category("Leilão")]
        public void DeveEntenderLancesEmOrdemCrescente()
        {
            //1a Parte: cenário
            Usuario joao = new Usuario("Joao");
            Usuario jose = new Usuario("Jose");
            Usuario maria = new Usuario("Maria");

            Leilao leilao = new Leilao("Playstation 3 Novo");

            leilao.Propoe(new Lance(maria, 250.0));
            leilao.Propoe(new Lance(joao, 300.0));
            leilao.Propoe(new Lance(jose, 400.0));

            //2a Parte: acao
            Avaliador leiloeiro = new Avaliador();
            leiloeiro.Avalia(leilao);

            //3a Parte: validacao
            double maiorEsperado = 400;
            double menorEsperado = 250;

            Assert.AreEqual(maiorEsperado, leiloeiro.MaiorLance, 0.0001);
            Assert.AreEqual(menorEsperado, leiloeiro.MenorLance, 0.0001);
        }

        [Test]
        [Category("Leilão")]
        public void DeveCalcularAMedia()
        {
            //1a Parte: cenário
            Usuario joao = new Usuario("Joao");
            Usuario jose = new Usuario("Jose");
            Usuario maria = new Usuario("Maria");

            Leilao leilao = new Leilao("Playstation 3 Novo");

            leilao.Propoe(new Lance(maria, 300.0));
            leilao.Propoe(new Lance(joao, 400.0));
            leilao.Propoe(new Lance(jose, 500.0));

            //2a Parte: acao
            Avaliador leiloeiro = new Avaliador();
            leiloeiro.Avalia(leilao);

            //3a Parte: validacao
            Assert.AreEqual(400, leiloeiro.ValorMedio, 0.0001);
        }

        [Test]
        [Category("Leilão")]
        public void DeveEntenderLeilaoComApenasUmLance()
        {
            Usuario joao = new Usuario("Joao");
            Leilao leilao = new Leilao("Playstation 3 Novo");

            leilao.Propoe(new Lance(joao, 1000.0));

            Avaliador leiloeiro = new Avaliador();
            leiloeiro.Avalia(leilao);

            Assert.AreEqual(1000, leiloeiro.MaiorLance, 0.0001);
            Assert.AreEqual(1000, leiloeiro.MenorLance, 0.0001);
        }

        [Test]
        [Category("Leilão")]
        public void DeveEncontrarOsTresMaioresLances()
        {
            Usuario joao = new Usuario("Joao");
            Usuario maria = new Usuario("maria");
            Leilao leilao = new Leilao("Playstation 3 Novo");

            leilao.Propoe(new Lance(maria, 200.0));
            leilao.Propoe(new Lance(joao, 300.0));
            leilao.Propoe(new Lance(maria, 400.0));

            Avaliador leiloeiro = new Avaliador();
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
            Usuario joao = new Usuario("Joao");
            Usuario maria = new Usuario("Maria");
            Usuario jose = new Usuario("Jose");

            Leilao leilao = new Leilao("Playstation 3 Novo");

            leilao.Propoe(new Lance(joao, 200.0));
            leilao.Propoe(new Lance(maria, 450.0));
            leilao.Propoe(new Lance(jose, 120.0));
            leilao.Propoe(new Lance(maria, 700.0));
            leilao.Propoe(new Lance(joao, 630.0));
            leilao.Propoe(new Lance(jose, 230.0));

            Avaliador leiloeiro = new Avaliador();
            leiloeiro.Avalia(leilao);

            Assert.AreEqual(700, leiloeiro.MaiorLance, 0.0001);
            Assert.AreEqual(120, leiloeiro.MenorLance, 0.0001);            
        }

        [Test]
        [Category("Leilão")]
        public void DeveEntenderLancesEmOrdemDecrescente()
        {
            //1a Parte: cenário
            Usuario joao = new Usuario("Joao");
            Usuario jose = new Usuario("Jose");
            Usuario maria = new Usuario("Maria");

            Leilao leilao = new Leilao("Playstation 3 Novo");

            leilao.Propoe(new Lance(maria, 400.0));
            leilao.Propoe(new Lance(joao, 300.0));
            leilao.Propoe(new Lance(jose, 200.0));
            leilao.Propoe(new Lance(maria, 100.0));

            //2a Parte: acao
            Avaliador leiloeiro = new Avaliador();
            leiloeiro.Avalia(leilao);

            //3a Parte: validacao

            Assert.AreEqual(400, leiloeiro.MaiorLance, 0.0001);
            Assert.AreEqual(100, leiloeiro.MenorLance, 0.0001);
        }

        [Test]
        [Category("Leilão")]
        public void DeveEncontrarOsTresMaioresLancesCom4Lances()
        {
            Usuario joao = new Usuario("Joao");
            Usuario maria = new Usuario("maria");
            Leilao leilao = new Leilao("Playstation 3 Novo");

            leilao.Propoe(new Lance(maria, 600.0));
            leilao.Propoe(new Lance(joao, 200.0));
            leilao.Propoe(new Lance(maria, 500.0));
            leilao.Propoe(new Lance(maria, 100.0));
            
            Avaliador leiloeiro = new Avaliador();
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
            Usuario joao = new Usuario("Joao");
            Usuario maria = new Usuario("maria");
            Leilao leilao = new Leilao("Playstation 3 Novo");

            leilao.Propoe(new Lance(joao, 800.0));
            leilao.Propoe(new Lance(maria, 400.0));

            Avaliador leiloeiro = new Avaliador();
            leiloeiro.Avalia(leilao);

            var maiores = leiloeiro.TresMaiores;

            Assert.AreEqual(2, maiores.Count);
            Assert.AreEqual(800, maiores[0].Valor, 0.0001);
            Assert.AreEqual(400, maiores[1].Valor, 0.0001);
        }

        [Test]
        [Category("Leilão")]
        public void DeveDevolverListaVaziaCasoNaoHajaLances()
        {
            Leilao leilao = new Leilao("Playstation 3 Novo");
            
            Avaliador leiloeiro = new Avaliador();
            leiloeiro.Avalia(leilao);

            var maiores = leiloeiro.TresMaiores;

            Assert.AreEqual(0, maiores.Count);
        }
    }
}
