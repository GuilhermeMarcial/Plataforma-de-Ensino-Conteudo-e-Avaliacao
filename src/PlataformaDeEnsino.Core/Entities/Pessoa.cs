using System.Collections.Generic;

namespace PlataformaDeEnsino.Core.Entities
{
    public class Pessoa
    {
        public int IdDaPessoa { get; private set; }
        public string NomeDaPessoa { get; private set; }
        public string SobrenomeDaPessoa { get; private set; }
        public string EmailDaPessoa { get; private set; }
        public string CpfDaPessoa { get; private set; }

        public IEnumerable<Aluno> Alunos { get; private set; }
        public IEnumerable<Professor> Professores { get; private set; }
        public IEnumerable<Coordenador> Coordenadores { get; private set; }
    }
}