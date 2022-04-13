using ControleBar.ConsoleApp.Compartilhado;

namespace ControleBar.ConsoleApp.ModuloConta
{
    internal class Conta : EntidadeBase
    {
        public string Codigo { get; set; }

        private string _codigo;

        public Conta(string codigo)
        {
            _codigo = codigo;
        }
        public override string ToString()
        {
            return "Id: " + id + "\nCódigo da conta: " + _codigo;
        }

    }
}