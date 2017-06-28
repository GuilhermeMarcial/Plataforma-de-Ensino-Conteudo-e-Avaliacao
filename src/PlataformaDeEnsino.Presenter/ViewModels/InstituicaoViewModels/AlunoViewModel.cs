using PlataformaDeEnsino.Identity.Models;

namespace PlataformaDeEnsino.Presenter.ViewModels.InstituicaoViewModels
{
    public class AlunoViewModel
    {
        public int? IdDoAluno { get; set; }
        public string IdDoUsuario { get; set; }
        public int NivelDoAluno { get; set; }
        public string CodigoDaTurma { get; set; }
        public string Role { get; set; }
        public AppUser Usuario { get; set; }

        public int IdDaPessoa { get; set; }
        public PessoaViewModel Pessoa { get; set; }
        public int IdDoCurso { get; set; }
    }
}