using System.ComponentModel.DataAnnotations;
using PlataformaDeEnsino.Presenter.ViewModels;

namespace PlataformaDeEnsino.Presenter.Areas.Coordenadores.ViewModels
{
    public class CoordenadorViewModel : PessoaViewModel
    { 
        [Key]
        public int IdDoCoordenador { get; set; }
        
        public int IdDoCurso { get; set; }
        public CursoViewModel Curso { get; set; }
    }
}