using ControleBar.ConsoleApp.Compartilhado;

namespace ControleBar.ConsoleApp.ModuloConta
{
    internal class Conta : EntidadeBase
    {
        public string Codigo { get; set; }

        public Conta(string codigo)
        {
            Codigo = codigo;
        }
        public bool estaAberta;
        public void Abrir()
        {
            if (!estaAberta)
            {
                estaAberta = true;
            }
            else
            {
                Fechar();
            }
        }

        public void Fechar()
        {
            estaAberta = false;
        }

        public override string ToString()
        {
            return "Id: " + id + "\nCódigo da conta: " + Codigo;
        }

    }
}