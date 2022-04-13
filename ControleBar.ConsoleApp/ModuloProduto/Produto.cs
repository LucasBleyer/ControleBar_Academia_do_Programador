using ControleBar.ConsoleApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
