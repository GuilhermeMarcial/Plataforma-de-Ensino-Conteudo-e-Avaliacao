using System.IO;
using PlataformaDeEnsino.Core.Services.Interfaces;
using PlataformaDeEnsino.Core.Services.Interfaces.ArquivosInterfaces;

namespace PlataformaDeEnsino.Core.Services.ArquivoServices
{
    public class DelecaoDeDiretoriosService : IDelecaoDeDiretoriosService
    {
        public void DeletarDiretorio(string diretorio)
        {
            if (Directory.Exists(diretorio))
            {
                Directory.Delete(diretorio, true);
            }
        }
    }
}