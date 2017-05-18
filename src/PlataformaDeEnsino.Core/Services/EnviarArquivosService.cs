using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using PlataformaDeEnsino.Core.Services.Interfaces;

namespace PlataformaDeEnsino.Core.Services
{
    public class EnviarArquivosService : IEnviarArquivosService
    {
        public async Task EnviarArquivosAsync(string diretorioDaUnidade, IFormFile file)
        {
            var extensaoDoArquivo = await Task.Run(() => Path.GetExtension(file.FileName));

            if (Directory.Exists(diretorioDaUnidade))
            {
                if (!file.Equals(null) || !file.Length.Equals(0))
                {
                    if (file.Length <= 1073741824)
                    {
                        if (extensaoDoArquivo.Equals(".pdf") && file.ContentType.Equals("application/pdf"))
                        {
                            var filePath = Path.Combine(diretorioDaUnidade, file.FileName.Trim('"'));
                            using (var stream = new FileStream(filePath, FileMode.Create))
                            {
                                await file.CopyToAsync(stream);
                            }
                        }
                    }
                }
            }
        }
    }
}