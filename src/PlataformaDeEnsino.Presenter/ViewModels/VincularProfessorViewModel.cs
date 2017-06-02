using System.Collections.Generic;
using PlataformaDeEnsino.Presenter.Areas.Professores.ViewModels;

namespace PlataformaDeEnsino.Presenter.ViewModels
{
    public class VincularProfessorViewModel
    {
        private UnidadeViewModel unidadeViewModel;
        private IEnumerable<ProfessorViewModel> professoresViewModel;
        private ProfessorViewModel professorViewModel;

        public VincularProfessorViewModel(UnidadeViewModel unidadeViewModel, IEnumerable<ProfessorViewModel> professoresViewModel)
        {
            this.unidadeViewModel = unidadeViewModel;
            this.professoresViewModel = professoresViewModel;
        }
        public VincularProfessorViewModel(UnidadeViewModel unidadeViewModel, ProfessorViewModel professorViewModel)
        {
            this.unidadeViewModel = unidadeViewModel;
            this.professorViewModel = professorViewModel;
        }
    }
}