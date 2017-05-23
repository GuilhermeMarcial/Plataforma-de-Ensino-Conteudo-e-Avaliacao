namespace PlataformaDeEnsino.Core.Entities
{
    public class Aluno : Pessoa
    {
        public int IdDoAluno { get; private set; }
        public int NivelDoAluno { get; private set; }
        public string CodigoDaTurma { get; private set; }

        public int IdDoCurso { get; private set; }
        public Curso Curso { get; private set; }
    }
}