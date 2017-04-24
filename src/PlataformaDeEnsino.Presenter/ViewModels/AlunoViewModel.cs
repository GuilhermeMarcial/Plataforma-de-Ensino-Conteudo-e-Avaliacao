using System.ComponentModel.DataAnnotations;
using PlataformaDeEnsino.Identity.Models;

namespace PlataformaDeEnsino.Presenter.ViewModels
{
    public class AlunoViewModel
    {
        [Key]
        public int IdDoAluno { get; set; }
        public string IdDoUsuario { get; set; }
        public string NomeDoAluno { get; set; }
        public string SobrenomeDoAluno { get; set; }
        public int NivelDoAluno { get; set; }
        public string EmailDoAluno { get; set; }
        public string CodigoDaTurma { get; set; }
        public string CpfDoAluno { get; set; }
        public string Role { get; set; }
        public AppUser Usuario { get; set; }

        public int IdDoCurso { get; set; }
    }
}