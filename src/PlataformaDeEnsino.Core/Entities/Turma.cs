using System.Collections.Generic;

namespace PlataformaDeEnsino.Core.Entities
{
    public class Turma
    {
        public int idDaTurma { get; private set; }
        public int codigoDaTurma { get; private set; }
        
        public ICollection<Modulo> modulos { get; private set; }
        public ICollection<Aluno> alunos { get; private set; }
    }
}