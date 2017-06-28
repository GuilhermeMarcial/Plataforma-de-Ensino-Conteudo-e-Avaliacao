using System.Collections.Generic;

namespace PlataformaDeEnsino.Core.Entities
{
    public class Professor
    {
        public int IdDoProfessor { get; private set; }

        public int IdDaPessoa { get; private set; }
        public Pessoa Pessoa { get; private set; }
        public ICollection<Unidade> Unidades { get; private set; }
    }
}