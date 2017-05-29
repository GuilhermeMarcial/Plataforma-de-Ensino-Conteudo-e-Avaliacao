using System.Collections.Generic;
using System.IO;

namespace PlataformaDeEnsino.Presenter.ViewModels
{
    public class ConteudoViewModel
    {
        public ConteudoViewModel(IEnumerable<ModuloViewModel> modulo, IEnumerable<UnidadeViewModel> unidade)
        {
            ModuloViewModel = modulo;
            UnidadeViewModel = unidade;
        }
        public ConteudoViewModel(IEnumerable<ModuloViewModel> modulo, IEnumerable<UnidadeViewModel> unidade, IEnumerable<FileInfo> arquivos)
        {
            ModuloViewModel = modulo;
            UnidadeViewModel = unidade;
            Arquivos = arquivos;
        }
        public IEnumerable<ModuloViewModel> ModuloViewModel { get; set; }
        public IEnumerable<UnidadeViewModel> UnidadeViewModel { get; set; }
        public IEnumerable<FileInfo> Arquivos { get; set; }
        public FileInfo Arquivo { get; set; }
    }
}