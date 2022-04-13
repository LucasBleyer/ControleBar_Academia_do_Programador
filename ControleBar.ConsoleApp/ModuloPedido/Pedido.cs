using ControleBar.ConsoleApp.Compartilhado;
using ControleBar.ConsoleApp.ModuloProduto;

namespace ControleBar.ConsoleApp.ModuloPedido
{
    internal class Pedido : EntidadeBase
    {
        public int Numero { get; set; }

        public int numero;
        public Produto produto;

        public Pedido(int numero)
        {
            this.numero = numero;
        }
        public override string ToString()
        {
            return "Id: " + id + "\nNúmero: " + numero +"\nProduto(s)" +produto;
        }
    }
}