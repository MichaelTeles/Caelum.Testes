using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caelum.Leilao
{
    public class Usuario
    {
        public int Id { get; private set; }
        public string Nome { get; private set; }

        public Usuario(string nome) : this(0, nome)
        {

        }

        public Usuario(int id, string nome)
        {
            this.Id = id;
            this.Nome = nome;
        }

        public override bool Equals(object obj)
        {
            if (this == obj)
                return true;
            if(obj == null)
                return false;
            if (this.GetType() != obj.GetType())
                return false;

            Usuario outro = (Usuario)obj;

            if (Id != outro.Id)
                return false;
            if (Nome == null)
            {
                if (outro.Nome != null)
                    return false;
            }
            else if (!Nome.Equals(outro.Nome))
                return false;

            return true;
        }
    }
}
