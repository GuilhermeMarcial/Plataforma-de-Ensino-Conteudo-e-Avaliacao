using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using PlataformaDeEnsino.Identity.Models;
using PlataformaDeEnsino.Presenter.ViewModels.InstituicaoViewModels;

namespace PlataformaDeEnsino.Presenter.ViewModels.InstituicaoViewModels
{
    public class ProfessorViewModel
    {
        public int IdDoProfessor { get; set; }
        public string IdDoUsuario { get; set; }
        public string Role { get; set; }
        public AppUser Usuario { get; set; }
        
        public int IdDaPessoa { get; set; }
        public PessoaViewModel Pessoa { get; set; }
        public ICollection<UnidadeViewModel> Unidades { get; set; }
    }
}