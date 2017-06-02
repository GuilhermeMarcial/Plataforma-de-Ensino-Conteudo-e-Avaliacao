using System.ComponentModel.DataAnnotations;
using PlataformaDeEnsino.Presenter.Areas.Professores.ViewModels;

namespace PlataformaDeEnsino.Presenter.ViewModels
{
    public class UnidadeViewModel
    {
        [Key]
        public int IdDaUnidade { get; set; }
        private string NomeDaUnidade { get; set; }
        private string DiretorioDaUnidade { get; set; }

        public int IdDoModulo { get; set; }
        public ModuloViewModel Modulo { get; set; }
        public int? IdDoProfessor { get; set; }
        public ProfessorViewModel Professor { get; set; }
    }
}