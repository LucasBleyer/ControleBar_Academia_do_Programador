using ControleBar.ConsoleApp.Compartilhado;

namespace ControleBar.ConsoleApp.ModuloProduto
{
    internal class Produto : EntidadeBase
    {
        public string Nome { get; set; }

        public string nome;

        public Produto(string nome)
        {
            this.nome = nome;
        }

        public override string ToString()
        {
            return "Nome: "+nome;
        }
    }
}
