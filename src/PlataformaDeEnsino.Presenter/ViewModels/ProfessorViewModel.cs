using System.Collections.Generic;
using PlataformaDeEnsino.Core.Entities;

namespace PlataformaDeEnsino.Presenter.ViewModels
{
    public class ProfessorViewModel
    {
        public int IdDoProfessor { get; set; }
        public string NomeDoProfessor { get; set; }
        public string SobrenomeDoProfessor { get; set; }
        public string CpfDoProfessor { get; set; }
        public string EstadoDoProfessor { get; set; }

        public ICollection<Unidade> Unidades { get; set; }
    }
}