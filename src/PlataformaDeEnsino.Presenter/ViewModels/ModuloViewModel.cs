using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PlataformaDeEnsino.Presenter.ViewModels
{
    public class ModuloViewModel
    {
        [Key]
        public int IdDoMobulo { get; set; }
        public string NomeDoModulo { get; set; }
        public bool EstadoDoModulo { get; set; }
        public string DiretorioDaTurma { get; set; }

        public int IdDaTurma { get; set; }
        public TurmaViewModel Turma { get; set; }
        public ICollection<UnidadeViewModel> Unidades { get; set; }
    }
}