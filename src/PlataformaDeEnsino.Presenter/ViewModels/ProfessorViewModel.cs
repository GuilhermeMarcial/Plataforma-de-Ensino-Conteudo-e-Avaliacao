using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using PlataformaDeEnsino.Identity.Models;

namespace PlataformaDeEnsino.Presenter.ViewModels
{
    public class ProfessorViewModel
    {
        [Key]
        public int IdDoProfessor { get; set; }
        public string IdDoUsuario { get; set; }
        public string NomeDoProfessor { get; set; }
        public string SobrenomeDoProfessor { get; set; }
        public string EmailDoProfessor { get; set; }
        public string CpfDoProfessor { get; set; }
        public string Role { get; set; }
        public AppUser Usuario { get; set; }

        public ICollection<UnidadeViewModel> Unidades { get; set; }
    }
}