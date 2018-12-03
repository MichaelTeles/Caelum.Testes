using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caelum.Leilao
{
    public class Leilao
    {
        public string Descricao { get; set; }
        public IList<Lance> Lances { get; set; }

        public Leilao(string descricao)
        {
            this.Descricao = descricao;
            this.Lances = new List<Lance>();
        }

        public void Propoe(Lance lance)
        {
            //Não posso ter dois lances seguidos do mesmo usuário
            //Não posso ter 5 lances totais do mesmo usuario
            if (Lances.Count == 0 || podeDarLance(lance.Usuario))
            {
                Lances.Add(lance);
            }
        }

        public void DobraLance(Usuario usuario)
        {
            Lance ultimoLance = ultimoLanceDo(usuario);
            if (ultimoLance != null)
            {
                Propoe(new Lance(usuario, ultimoLance.Valor * 2));
            }
        }

        private Lance ultimoLanceDo(Usuario usuario)
        {
            Lance ultimo = null;

            foreach (Lance lance in Lances)
            {
                if (lance.Usuario.Equals(usuario))
                {
                    ultimo = lance;
                }
            }

            return ultimo;
        }

        private Lance ultimoLanceDado()
        {
            return Lances[Lances.Count - 1];
        }

        private bool podeDarLance(Usuario usuario)
        {
            return (!ultimoLanceDado().Usuario.Equals(usuario)
                && qtdDeLancesDo(usuario) < 5);
            
        }

        private int qtdDeLancesDo(Usuario usuario)
        {
            int total = 0;
            foreach (var l in Lances)
            {
                if (l.Usuario.Equals(usuario)) total++;
            }

            return total;
        }
    }
}
