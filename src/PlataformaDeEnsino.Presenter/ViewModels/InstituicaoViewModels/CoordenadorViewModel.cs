using System.ComponentModel.DataAnnotations;
using PlataformaDeEnsino.Presenter.ViewModels;
using PlataformaDeEnsino.Presenter.ViewModels.InstituicaoViewModels;

namespace PlataformaDeEnsino.Presenter.Coordenadores.ViewModels.InstituicaoViewModels
{
    public class CoordenadorViewModel
    { 
        [Key]
        public int IdDoCoordenador { get; set; }
        
        public int IdDaPessoa { get; set; }
        public PessoaViewModel Pessoa { get; set; }
        public int IdDoCurso { get; set; }
        public CursoViewModel Curso { get; set; }
    }
}