namespace PlataformaDeEnsino.Core.Entities
{
    public class Coordenador
    {
        public int IdDoCoordenador { get; private set; }
        public string NomeDoCoordenador { get; private set; }

        public int IdDaTurma { get; private set; }
        public Turma Turma { get; private set; }
    }
}