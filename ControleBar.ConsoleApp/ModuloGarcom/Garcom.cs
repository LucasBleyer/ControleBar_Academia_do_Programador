using ControleBar.ConsoleApp.Compartilhado;
using System;

namespace ControleBar.ConsoleApp.ModuloGarcom
{
    public class Garcom : EntidadeBase
    {
        public string Nome { get; set; }
        public string cpf { get; set; }
        public decimal Gorjeta { get; set; } = 0m;

        public Garcom(string nome, string cpf)
        {
            Nome = nome;
            this.cpf = cpf;
        }

        public override string ToString()
        {
            return "Id: " + id + "\nNome do garçom: " + Nome + "\nCPF do garçom: " + cpf + "\nGorjetas recebidas: R$" + Gorjeta;
        }

        public void ReceberGorjeta(decimal gorjetaCalculada)
        {
            Gorjeta += gorjetaCalculada;
        }
    }
}
