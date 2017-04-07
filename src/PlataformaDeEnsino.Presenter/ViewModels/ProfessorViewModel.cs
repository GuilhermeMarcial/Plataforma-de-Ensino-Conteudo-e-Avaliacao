using System.Collections.Generic;

namespace PlataformaDeEnsino.Presenter.ViewModels
{
    public class ProfessorViewModel
    {
        public int IdDoProfessor { get; set; }
        public string NomeDoProfessor { get; set; }
        public string SobrenomeDoProfessor { get; set; }
        public string CpfDoProfessor { get; set; }
        public bool EstadoDoProfessor { get; set; }

        public ICollection<UnidadeViewModel> Unidades { get; set; }
    }
}