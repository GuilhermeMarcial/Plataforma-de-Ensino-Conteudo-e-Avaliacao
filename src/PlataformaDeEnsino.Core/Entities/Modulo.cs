using System.Collections.Generic;

namespace PlataformaDeEnsino.Core.Entities
{
    public class Modulo
    {
        public int IdDoModulo { get; private set; }
        public string NomeDoModulo { get; private set; }
        public int NivelDoModulo { get; private set; }

        public int IdDoCurso { get; private set; }
        public Curso Curso { get; private set; }
        public ICollection<Unidade> Unidades { get; private set; }
    }
}