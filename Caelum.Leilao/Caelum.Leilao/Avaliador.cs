using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caelum.Leilao
{
    public class Avaliador
    {
        private double maiorDeTodos = Double.MinValue;
        private double menorDeTodos = Double.MaxValue;
        private double valorMedio = 0;
        private List<Lance> maiores;

        public void Avalia(Leilao leilao)
        {
            if (leilao.Lances.Count == 0)
                throw new Exception("Não é possivel avaliar um leilão sem lances");

            foreach(var lance in leilao.Lances)
            {
                if(lance.Valor > maiorDeTodos)
                {
                    maiorDeTodos = lance.Valor;
                }
                
                if(lance.Valor < menorDeTodos)
                {
                    menorDeTodos = lance.Valor;
                }

                valorMedio += lance.Valor;
            }

            valorMedio = valorMedio / leilao.Lances.Count;

            pegaOsMaioresNo(leilao);
        }

        private void pegaOsMaioresNo(Leilao leilao)
        {
            maiores = new List<Lance>(leilao.Lances.OrderByDescending(x => x.Valor).Take(3));
            //maiores = maiores.GetRange(0, maiores.Count > 3 ? 3 : maiores.Count);
        }

        public double MaiorLance
        {
            get { return maiorDeTodos; }
        }

        public double MenorLance
        {
            get { return menorDeTodos; }
        }

        public double ValorMedio
        {
            get { return valorMedio; }
        }

        public List<Lance> TresMaiores
        {
            get { return this.maiores; }
        }

    }
}
