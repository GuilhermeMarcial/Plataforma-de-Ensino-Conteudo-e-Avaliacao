using System.Collections.Generic;

namespace PlataformaDeEnsino.Core.Entities
{
    public class Professor : Pessoa
    {
        public int IdDoProfessor { get; private set; }

        public ICollection<Unidade> Unidades { get; private set; }
    }
}