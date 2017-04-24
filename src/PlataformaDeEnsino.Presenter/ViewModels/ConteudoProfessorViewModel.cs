using System.Collections.Generic;
using System.IO;

namespace PlataformaDeEnsino.Presenter.ViewModels
{
    public class ConteudoProfessorViewModel
    {
        public ConteudoProfessorViewModel(IEnumerable<UnidadeViewModel> unidade)
        {
            UnidadeViewModel = unidade;
        }
        public ConteudoProfessorViewModel(IEnumerable<UnidadeViewModel> unidade, IEnumerable<FileInfo> arquivos)
        {
            UnidadeViewModel = unidade;
            Arquivos = arquivos;
        }
        public IEnumerable<UnidadeViewModel> UnidadeViewModel { get; set; }
        public IEnumerable<FileInfo> Arquivos { get; set; }
        public FileInfo Arquivo { get; set; }

    }
}