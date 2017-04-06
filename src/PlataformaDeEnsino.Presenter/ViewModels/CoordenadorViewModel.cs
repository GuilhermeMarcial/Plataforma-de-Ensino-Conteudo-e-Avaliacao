using PlataformaDeEnsino.Core.Entities;

namespace PlataformaDeEnsino.Presenter.ViewModels
{
    public class CoordenadorViewModel
    {
        public int IdDoCoordenador { get; set; }
        public string NomeDoCoordenador { get; set; }

        public int IdDaTurma { get; set; }
        public Turma Turma { get; set; }
    }
}