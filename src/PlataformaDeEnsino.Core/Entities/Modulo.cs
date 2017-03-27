using System.Collections.Generic;

namespace PlataformaDeEnsino.Core.Entities
{
    public class Modulo
    {
        public int idDoMobulo { get; private set; }
        public string nomeDoModulo { get; private set; }
        public bool estadoDoModulo { get; private set; }
        
        public int idDaTurma { get; private set; }
        public Turma turma { get; private set; }
        public ICollection<Unidade> unidades { get; private set; }
    }
}