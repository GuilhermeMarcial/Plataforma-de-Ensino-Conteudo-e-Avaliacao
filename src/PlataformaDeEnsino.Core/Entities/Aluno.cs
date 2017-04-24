namespace PlataformaDeEnsino.Core.Entities
{
    public class Aluno
    {
        public int IdDoAluno { get; private set; }
        public string NomeDoAluno { get; private set; }
        public string SobrenomeDoAluno { get; private set; }
        public string EmailDoAluno { get; private set; }
        public string CpfDoAluno { get; private set; }
        public int NivelDoAluno { get; private set; }
        public string CodigoDaTurma { get; private set; }

        public int IdDoCurso { get; private set; }
        public Curso Curso { get; private set; }
    }
}