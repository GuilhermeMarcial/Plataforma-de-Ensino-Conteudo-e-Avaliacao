namespace PlataformaDeEnsino.Presenter.ViewModels
{
    public class CoordenadorViewModel
    {
        public int IdDoCoordenador { get; set; }
        public string NomeDoCoordenador { get; set; }
        public string SobrenomeDoCoordenador { get; set; }
        public string CpfDoCoordenador { get; set; }

        public int IdDoCurso { get; set; }
        public CursoViewModel Curso { get; set; }
    }
}