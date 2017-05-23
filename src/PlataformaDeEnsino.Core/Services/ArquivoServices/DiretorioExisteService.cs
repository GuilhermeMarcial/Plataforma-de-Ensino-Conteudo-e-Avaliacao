using System.IO;
using PlataformaDeEnsino.Core.Services.InterfacesServices.ArquivosInterfaces;

namespace PlataformaDeEnsino.Core.Services.ArquivoServices
{
    public class DiretorioExisteService : IDiretorioExisteService
    {
        public bool DiretorioExiste(string caminhoDoArquivo)
        {
            return Directory.Exists(caminhoDoArquivo);
        }
    }
}