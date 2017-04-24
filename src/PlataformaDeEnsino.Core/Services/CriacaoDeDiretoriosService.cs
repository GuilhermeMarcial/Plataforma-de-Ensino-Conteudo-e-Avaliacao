using System.IO;
using PlataformaDeEnsino.Core.Services.Interfaces;

namespace PlataformaDeEnsino.Core.Services
{
    public class CriacaoDoDiretorioService : ICriacaoDoDiretorioService
    {
        public void CriarDiretorio(string caminhoDoDiretorio)
        {
            if (!Directory.Exists(caminhoDoDiretorio))
            {
                Directory.CreateDirectory(caminhoDoDiretorio);
            }
        }
    }
}