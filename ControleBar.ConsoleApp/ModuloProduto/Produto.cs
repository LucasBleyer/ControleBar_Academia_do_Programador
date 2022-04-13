using ControleBar.ConsoleApp.Compartilhado;

namespace ControleBar.ConsoleApp.ModuloProduto
{
    internal class Produto : EntidadeBase
    {
        public string Nome { get; set; }

        public Produto(string nome)
        {
            Nome = nome;
        }

        public override string ToString()
        {
            return "Id: " + id + "\nNome: "+Nome;
        }
    }
}
