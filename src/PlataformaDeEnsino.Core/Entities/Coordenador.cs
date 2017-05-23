namespace PlataformaDeEnsino.Core.Entities
{
    public class Coordenador : Pessoa
    {
        public int IdDoCoordenador { get; private set; }
        
        public int IdDoCurso { get; private set; }
        public Curso Curso { get; private set; }
    }
}