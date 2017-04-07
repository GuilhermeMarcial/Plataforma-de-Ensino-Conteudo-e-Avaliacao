using System.Collections.Generic;

namespace PlataformaDeEnsino.Core.Entities
{
    public class Curso
    {
        public int IdDoCurso { get; private set; }
        public string NomeDoCurso { get; private set; }
        public int QuantidadeDeModulos { get; private set; }

        public ICollection<Turma> Turmas { get; private set; }
        public Coordenador Coordenador { get; private set; }

    }
}