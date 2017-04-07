using System.Collections.Generic;

namespace PlataformaDeEnsino.Presenter.ViewModels
{
    public class TurmaViewModel
    {
        public int IdDaTurma { get; set; }
        public string CodigoDaTurma { get; set; }
        public string DiretorioDaTurma { get; set; }

        public int IdDoCurso { get; set; }
        public CursoViewModel Curso { get; set; }
        public ICollection<ModuloViewModel> Modulos { get; set; }
        public ICollection<AlunoViewModel> Alunos { get; set; }
    }
}