using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PlataformaDeEnsino.Core.Entities;
using PlataformaDeEnsino.Core.Repositories;
using PlataformaDeEnsino.Core.Services.Interfaces;

namespace PlataformaDeEnsino.Core.Services
{
    public class AlunoService : ServiceBase<Aluno>, IAlunoService
    {
        private readonly IAlunoRepository _alunoRepository;
        public AlunoService(IAlunoRepository alunoRepository) : base(alunoRepository)
        {
            _alunoRepository = alunoRepository;
        }

        public async Task<Aluno> ConsultarAlunoPeloCpfAsync(string CpfDoAluno)
        {
            return await _alunoRepository.ConsultarAlunoPeloCpfAsync(CpfDoAluno);
        }

        public async Task<IEnumerable<Aluno>> SelecionarAlunosPeloCursoAsync(int idDoCurso)
        {
            return await _alunoRepository.SelecionarAlunosPeloCursoAsync(idDoCurso);
        }
    }
}