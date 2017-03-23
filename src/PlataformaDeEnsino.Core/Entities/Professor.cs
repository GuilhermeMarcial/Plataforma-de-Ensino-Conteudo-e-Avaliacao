using System.Collections.Generic;

namespace PlataformaDeEnsino.Core.Entities
{
    public class Professor
    {
        public int idDoProfessor { get; private set; }
        public string nomeDoProfessor { get; private set; }

        public ICollection<Unidade> unidades { get; private set; }


    }
}