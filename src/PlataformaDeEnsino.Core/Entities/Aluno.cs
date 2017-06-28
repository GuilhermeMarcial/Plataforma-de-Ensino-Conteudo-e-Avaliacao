namespace PlataformaDeEnsino.Core.Entities
{
    public class Aluno
    {
        public int IdDoAluno { get; private set; }
        public int NivelDoAluno { get; private set; }
        public string CodigoDaTurma { get; private set; }


        public int IdDaPessoa { get; private set; }
        public Pessoa Pessoa { get; private set; }
        public int IdDoCurso { get; private set; }
        public Curso Curso { get; private set; }
    }
}