using System.IO;
using System.Threading.Tasks;
using PlataformaDeEnsino.Core.Services.Interfaces;
using PlataformaDeEnsino.Core.Services.Interfaces.ArquivosInterfaces;

namespace PlataformaDeEnsino.Core.Services.ArquivoServices
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