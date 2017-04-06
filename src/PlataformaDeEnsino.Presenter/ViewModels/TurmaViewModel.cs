using System.Collections.Generic;
using PlataformaDeEnsino.Core.Entities;

namespace PlataformaDeEnsino.Presenter.ViewModels
{
    public class TurmaViewModel
    {
        public int IdDaTurma { get; set; }
        public int CodigoDaTurma { get; set; }
        public string DiretorioDaTurma { get; set; }

        public ICollection<Coordenador> Coordenadores { get; set; }
        public ICollection<Modulo> Modulos { get; set; }
        public ICollection<Aluno> Alunos { get; set; }
    }
}