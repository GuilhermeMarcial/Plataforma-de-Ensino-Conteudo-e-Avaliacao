using PlataformaDeEnsino.Core.Entities;
using PlataformaDeEnsino.Application.AppServices.Interfaces;
using PlataformaDeEnsino.Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PlataformaDeEnsino.Application.AppServices.Interfaces.InsitituicaoInterfaces;
using PlataformaDeEnsino.Core.Services.Interfaces.InstituicaoInterfaces;

namespace PlataformaDeEnsino.Application.AppServices.InstituicaoAppServices
{
    public class AlunoAppService : AppServiceBase<Aluno>, IAlunoAppService
    {
        private readonly IAlunoService _alunoService;

        public AlunoAppService(IAlunoService alunoService) : base(alunoService)
        {
            _alunoService = alunoService;
        }

        public async Task<Aluno> ConsultarAlunoPeloCpfAsync(string cpfDoAluno)
        {
            return await  _alunoService.ConsultarAlunoPeloCpfAsync(cpfDoAluno);
        }
        public async Task<IEnumerable<Aluno>> SelecionarAlunosPeloCursoAsync(int idDoCurso)
        {
            return await  _alunoService.SelecionarAlunosPeloCursoAsync(idDoCurso);
        }
    }
}