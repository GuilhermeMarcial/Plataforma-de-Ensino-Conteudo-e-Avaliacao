using System.ComponentModel.DataAnnotations;
using PlataformaDeEnsino.Identity.Models;
using PlataformaDeEnsino.Presenter.ViewModels.InstituicaoViewModels;

namespace PlataformaDeEnsino.Presenter.ViewModels.InstituicaoViewModels
{
    public class AlunoViewModel : PessoaViewModel
    {
        [Key]
        public int? IdDoAluno { get; set; }
        public string IdDoUsuario { get; set; }
        public int NivelDoAluno { get; set; }
        public string CodigoDaTurma { get; set; }
        public string Role { get; set; }
        public AppUser Usuario { get; set; }

        public int IdDoCurso { get; set; }
    }
}