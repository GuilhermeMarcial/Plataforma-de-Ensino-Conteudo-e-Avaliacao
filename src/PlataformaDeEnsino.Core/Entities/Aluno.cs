namespace PlataformaDeEnsino.Core.Entities
{
    public class Aluno
    {
        public int idDoAluno { get; private set; }
        public int idDaTurma { get; private set; }
        public string nomeDoAluno { get; private set; }
        
        public Turma turma { get; private set; }
    }
}