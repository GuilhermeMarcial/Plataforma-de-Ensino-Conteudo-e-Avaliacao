using PlataformaDeEnsino.Core.Entities;

namespace PlataformaDeEnsino.Application.AppServices.Interfaces
{
    public interface IProfessorAppService : IAppServiceBase<Professor>
    {
         Professor ConsultarPeloCpf(string cpfDoProfessor);
         Professor ConsultarPelaUnidade(int idDaUnidade);
    }
}