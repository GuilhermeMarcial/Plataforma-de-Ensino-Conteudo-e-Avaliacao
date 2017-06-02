using System.Collections.Generic;
using PlataformaDeEnsino.Presenter.Areas.Professores.ViewModels;

namespace PlataformaDeEnsino.Presenter.ViewModels
{
    public class VincularProfessorViewModel
    {
        private UnidadeViewModel unidadeViewModel;
        private IEnumerable<ProfessorViewModel> professoresViewModel;
        private ProfessorViewModel professorViewModel;

        public VincularProfessorViewModel(UnidadeViewModel UnidadeViewModel, IEnumerable<ProfessorViewModel> ProfessoresViewModel)
        {
            unidadeViewModel = UnidadeViewModel;
            professoresViewModel = ProfessoresViewModel;
        }
        public VincularProfessorViewModel(UnidadeViewModel UnidadeViewModel, ProfessorViewModel ProfessorViewModel)
        {
            unidadeViewModel = UnidadeViewModel;
            professorViewModel = ProfessorViewModel;
        }

    }
}