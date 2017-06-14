using System.ComponentModel.DataAnnotations;


namespace PlataformaDeEnsino.Presenter.ViewModels.InstituicaoViewModels
{
    public class UnidadeViewModel
    {
        [Key]
        public int IdDaUnidade { get; set; }
        public string NomeDaUnidade { get; set; }
        public string DiretorioDaUnidade { get; set; }

        public int IdDoModulo { get; set; }
        public ModuloViewModel Modulo { get; set; }
        public int? IdDoProfessor { get; set; }
        public ProfessorViewModel Professor { get; set; }
    }
}