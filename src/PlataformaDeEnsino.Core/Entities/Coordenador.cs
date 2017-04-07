namespace PlataformaDeEnsino.Core.Entities
{
    public class Coordenador
    {
        public int IdDoCoordenador { get; private set; }
        public string NomeDoCoordenador { get; private set; }
        public string SobrenomeDoCoordenador { get; private set; }
        public string CpfDoCoordenador { get; private set; }

        public int IdDoCurso { get; private set; }
        public Curso Curso { get; private set; }
    }
}