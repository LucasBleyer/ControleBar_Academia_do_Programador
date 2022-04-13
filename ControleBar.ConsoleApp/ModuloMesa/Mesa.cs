using ControleBar.ConsoleApp.Compartilhado;

namespace ControleBar.ConsoleApp.ModuloMesa
{
    internal class Mesa : EntidadeBase
    {
        public int Numero { get; set; }

        public Mesa(int numero)
        {
            Numero = numero;
        }

        public override string ToString()
        {
            return "Id: " + id +"\nNúmero da mesa: " + Numero;
        }
    }
}
