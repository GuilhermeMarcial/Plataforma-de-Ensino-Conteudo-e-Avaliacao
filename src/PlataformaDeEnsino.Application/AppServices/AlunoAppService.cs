using PlataformaDeEnsino.Core.Entities;
using PlataformaDeEnsino.Application.AppServices.Interfaces;
using PlataformaDeEnsino.Core.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace PlataformaDeEnsino.Application.AppServices
{
    public class AlunoAppService : AppServiceBase<Aluno>, IAlunoAppService
    {
        private readonly IAlunoService _alunoService;
        public AlunoAppService(IAlunoService alunoService) : base(alunoService)
        {
            _alunoService = alunoService;
        }

        public Aluno ConsultarAlunoPeloCpf(string CpfDoAluno)
        {
            return _alunoService.ConsultarAlunoPeloCpf(CpfDoAluno);
        }
        public IEnumerable<Aluno> SelecionarAlunosPeloCurso(int idDoCurso)
        {
            return _alunoService.SelecionarAlunosPeloCurso(idDoCurso);
        }
    }
}