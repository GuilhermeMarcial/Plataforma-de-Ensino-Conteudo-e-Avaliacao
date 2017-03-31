namespace PlataformaDeEnsino.Core.Entities
{
    public class Aluno
    {
        public int IdDoAluno { get; private set; }
        public string NomeDoAluno { get; private set; }
        
        public int IdDaTurma { get; private set; }
        public Turma Turma { get; private set; }
    }
}