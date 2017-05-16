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

        public Aluno ConsultarAlunoPeloCpf(string CpfDoAluno)
        {
            return _alunoRepository.ConsultarAlunoPeloCpf(CpfDoAluno);
        }

        public IEnumerable<Aluno> SelecionarAlunosPeloCurso(int idDoCurso)
        {
            return _alunoRepository.SelecionarAlunosPeloCurso(idDoCurso);
        }
    }
}