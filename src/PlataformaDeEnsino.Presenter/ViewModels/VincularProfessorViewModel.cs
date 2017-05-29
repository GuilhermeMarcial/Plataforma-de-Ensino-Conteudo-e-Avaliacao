using System.Collections.Generic;
using PlataformaDeEnsino.Presenter.Areas.Professores.ViewModels;

namespace PlataformaDeEnsino.Presenter.ViewModels
{
    public class VincularProfessorViewModel
    {
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

        public UnidadeViewModel unidadeViewModel;
        public IEnumerable<ProfessorViewModel> professoresViewModel;
        public ProfessorViewModel professorViewModel;
    }
}