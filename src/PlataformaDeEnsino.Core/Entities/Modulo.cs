using System.Collections.Generic;

namespace PlataformaDeEnsino.Core.Entities
{
    public class Modulo
    {
        public int IdDoMobulo { get; private set; }
        public string NomeDoModulo { get; private set; }
        public bool EstadoDoModulo { get; private set; }
        public string DiretorioDaTurma { get; private set; }

        public int IdDaTurma { get; private set; }
        public Turma Turma { get; private set; }
        public ICollection<Unidade> Unidades { get; private set; }
    }
}