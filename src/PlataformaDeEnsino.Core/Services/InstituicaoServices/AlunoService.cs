using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PlataformaDeEnsino.Core.Entities;
using PlataformaDeEnsino.Core.Repositories;
using PlataformaDeEnsino.Core.Repositories.InstituicaoRepositories;
using PlataformaDeEnsino.Core.Services.Interfaces;
using PlataformaDeEnsino.Core.Services.Interfaces.InstituicaoInterfaces;

namespace PlataformaDeEnsino.Core.Services.InstituicaoServices
{
    public class AlunoService : ServiceBase<Aluno>, IAlunoService
    {
        private readonly IAlunoRepository _alunoRepository;

        public AlunoService(IAlunoRepository alunoRepository) : base(alunoRepository)
        {
            _alunoRepository = alunoRepository;
        }

        public async Task<Aluno> ConsultarAlunoPeloCpfAsync(string cpfDoAluno)
        {
            return await _alunoRepository.ConsultarAlunoPeloCpfAsync(cpfDoAluno);
        }

        public async Task<IEnumerable<Aluno>> SelecionarAlunosPeloCursoAsync(int idDoCurso)
        {
            return await _alunoRepository.SelecionarAlunosPeloCursoAsync(idDoCurso);
        }
    }
}