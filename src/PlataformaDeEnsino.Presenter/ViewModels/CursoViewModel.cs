using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PlataformaDeEnsino.Presenter.ViewModels
{
    public class CursoViewModel
    {
        [Key]
        public int IdDoCurso { get; set; }
        public string NomeDoCurso { get; set; }
        public int QuantidadeDeModulos { get; set; }

        public ICollection<TurmaViewModel> Turmas { get; set; }
        public CoordenadorViewModel Coordenador { get; set; }
    }
}