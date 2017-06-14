using System.Collections.Generic;

namespace PlataformaDeEnsino.Presenter.ViewModels.InstituicaoViewModels
{
    public class ModuloViewModel
    {
        public int IdDoModulo { get; set; }
        public string NomeDoModulo { get; set; }
        public int NivelDoModulo { get; private set; }

        public int IdDoCurso { get; set; }
        public CursoViewModel Curso { get; set; }
        public ICollection<UnidadeViewModel> Unidades { get; set; }
    }
}