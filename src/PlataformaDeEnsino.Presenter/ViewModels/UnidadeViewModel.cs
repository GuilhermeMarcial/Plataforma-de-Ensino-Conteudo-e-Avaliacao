using PlataformaDeEnsino.Core.Entities;

namespace PlataformaDeEnsino.Presenter.ViewModels
{
    public class UnidadeViewModel
    {
        public int IdDaUnidada { get; set; }
        public string NomeDaUnidade { get; set; }
        public string DiretorioDaUnidade { get; set; }

        public int IdDoModulo { get; set; }
        public Modulo Modulo { get; set; }
        public int IdDoProfessor { get; set; }
        public Professor Professor { get; set; }
    }
}