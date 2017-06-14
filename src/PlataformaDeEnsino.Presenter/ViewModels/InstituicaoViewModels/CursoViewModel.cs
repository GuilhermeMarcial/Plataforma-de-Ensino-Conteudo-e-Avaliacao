using System.ComponentModel.DataAnnotations;

namespace PlataformaDeEnsino.Presenter.ViewModels.InstituicaoViewModels
{
    public class CursoViewModel
    {
        public int IdDoCurso { get; set; }
        public string NomeDoCurso { get; set; }
        public int QuantidadeDeModulos { get; set; }
    }
}