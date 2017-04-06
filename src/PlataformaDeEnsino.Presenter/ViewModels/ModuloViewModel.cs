using System.Collections.Generic;
using PlataformaDeEnsino.Core.Entities;

namespace PlataformaDeEnsino.Presenter.ViewModels
{
    public class ModuloViewModel
    {
        public int IdDoMobulo { get; set; }
        public string NomeDoModulo { get; set; }
        public bool EstadoDoModulo { get; set; }
        public string DiretorioDaTurma { get; set; }

        public int IdDaTurma { get; set; }
        public Turma Turma { get; set; }
        public ICollection<Unidade> Unidades { get; set; }
    }
}