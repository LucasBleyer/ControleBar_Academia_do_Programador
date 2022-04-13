using ControleBar.ConsoleApp.Compartilhado;

namespace ControleBar.ConsoleApp.ModuloMesa
{
    internal class Mesa : EntidadeBase
    {
        public int numero;

        public Mesa(int numero)
        {
            this.numero = numero;
        }

        public override string ToString()
        {
            return "Id: " + id +"\nNúmero da mesa: " + numero;
        }
    }
}
