using ControleBar.ConsoleApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleBar.ConsoleApp.ModuloMesa
{
    internal class Mesa : EntidadeBase
    {
        private int Numero { get; set; }

        private int _numero;

        public Mesa(int _numero)
        {
            this._numero = _numero;
        }
    }
}
