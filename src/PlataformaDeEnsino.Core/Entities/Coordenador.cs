namespace PlataformaDeEnsino.Core.Entities
{
    public class Coordenador
    {
        public int IdDoCoordenador { get; private set; }
        
        public int IdDaPessoa { get; private set; }
        public Pessoa Pessoa { get; private set; }
        public int IdDoCurso { get; private set; }
        public Curso Curso { get; private set; }
    }
}