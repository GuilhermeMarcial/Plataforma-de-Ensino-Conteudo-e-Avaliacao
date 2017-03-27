namespace PlataformaDeEnsino.Core.Entities
{
    public class Coordenador
    {
        public int idDoCoordenador { get; private set; }
        public string nomeDoCoordenador { get; private set; }

        public int idDaTurma { get; private set; }
        public Turma turma { get; private set; }
    }
}