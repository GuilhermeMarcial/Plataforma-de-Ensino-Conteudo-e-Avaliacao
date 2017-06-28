using System.Collections.Generic;
using PlataformaDeEnsino.Identity.Models;

namespace PlataformaDeEnsino.Presenter.ViewModels.InstituicaoViewModels
{
    public class EditarProfessorViewModel
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