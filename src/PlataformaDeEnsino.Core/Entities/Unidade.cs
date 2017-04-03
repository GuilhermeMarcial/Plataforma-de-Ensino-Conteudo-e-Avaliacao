namespace PlataformaDeEnsino.Core.Entities
{
    public class Unidade
    {
        public int IdDaUnidada { get; private set; }
        public string NomeDaUnidade { get; private set; }
        public string DiretorioDaUnidade { get; private set; }

        public int IdDoModulo { get; private set; }
        public Modulo Modulo { get; private set; }
        public int IdDoProfessor { get; private set; }
        public Professor Professor { get; private set; }
    }
}