using System.Collections.Generic;

namespace PlataformaDeEnsino.Core.Entities
{
    public class Turma
    {
        public int IdDaTurma { get; private set; }
        public string CodigoDaTurma { get; private set; }
        public string DiretorioDaTurma { get; private set; }

        public int IdDoCurso { get; private set; }
        public Curso Curso { get; private set; }
        public ICollection<Modulo> Modulos { get; private set; }
        public ICollection<Aluno> Alunos { get; private set; }
    }
}