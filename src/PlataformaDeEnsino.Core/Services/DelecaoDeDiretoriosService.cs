using System.IO;
using PlataformaDeEnsino.Core.Services.Interfaces;

namespace PlataformaDeEnsino.Core.Services
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