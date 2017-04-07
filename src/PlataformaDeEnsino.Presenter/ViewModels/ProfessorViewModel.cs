using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PlataformaDeEnsino.Presenter.ViewModels
{
    public class ProfessorViewModel
    {
        [Key]
        public int IdDoProfessor { get; set; }
        public string NomeDoProfessor { get; set; }
        public string SobrenomeDoProfessor { get; set; }
        public string CpfDoProfessor { get; set; }
        public bool EstadoDoProfessor { get; set; }

        public ICollection<UnidadeViewModel> Unidades { get; set; }
    }
}