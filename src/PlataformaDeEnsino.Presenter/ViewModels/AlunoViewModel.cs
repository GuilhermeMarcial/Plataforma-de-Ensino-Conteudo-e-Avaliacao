namespace PlataformaDeEnsino.Presenter.ViewModels
{
    public class AlunoViewModel
    {
        public int IdDoAluno { get; set; }
        public string NomeDoAluno { get; set; }
        public string SobrenomeDoAluno { get; set; }
        public string CpfDoAluno { get; set; }
        public bool EstadoDoAluno { get; set; }

        public int IdDaTurma { get; set; }
        public TurmaViewModel Turma { get; set; }   
    }
}