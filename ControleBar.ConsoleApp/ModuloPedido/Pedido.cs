using ControleBar.ConsoleApp.Compartilhado;
using ControleBar.ConsoleApp.ModuloProduto;
using System.Collections.Generic;

namespace ControleBar.ConsoleApp.ModuloPedido
{
    internal class Pedido : EntidadeBase
    {
        public int Numero { get; set; }

        public List<Produto> produtos;

        public Pedido(int numero)
        {
            this.Numero = numero;
        }
        public override string ToString()
        {
            return "Id: " + id + "\nNúmero: " + Numero +"\nProduto(s)" +produtos;
        }
    }
}