namespace PlataformaDeEnsino.Core.Entities
{
    public class Unidade
    {
        public int idDaUnidada { get; private set; }
        public string nomeDaUnidade { get; private set; }
        public string DiretorioDaUnidade { get; private set; }

        public int idDoModulo { get; private set; }
        public Modulo modulo { get; private set; }
        public int idDoProfessor { get; private set; }
        public Professor professor { get; private set; }

    }
}