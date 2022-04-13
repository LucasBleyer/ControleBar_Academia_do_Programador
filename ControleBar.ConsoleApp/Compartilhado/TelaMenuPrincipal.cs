﻿using ControleBar.ConsoleApp.ModuloPedido;
using ControleBar.ConsoleApp.ModuloProduto;
using ControleBar.ConsoleApp.ModuloMesa;
using ControleBar.ConsoleApp.ModuloGarcom;
using System;

namespace ControleBar.ConsoleApp.Compartilhado
{
    public class TelaMenuPrincipal
    {
        private readonly IRepositorio<Garcom> repositorioGarcom;
        private readonly TelaCadastroGarcom telaCadastroGarcom;

        private readonly IRepositorio<Mesa> repositorioMesa;
        private readonly TelaCadastroMesa telaCadastroMesa;

        private readonly IRepositorio<Produto> repositorioProduto;
        private readonly TelaCadastroProduto telaCadastoProduto;

        private readonly IRepositorio<Pedido> repositorioPedido;
        private readonly TelaCadastroPedido telaCadastoPedido;
        
        public TelaMenuPrincipal(Notificador notificador)
        {
            repositorioGarcom = new RepositorioGarcom();
            telaCadastroGarcom = new TelaCadastroGarcom(repositorioGarcom, notificador);

            repositorioMesa = new RepositorioMesa();
            telaCadastroMesa = new TelaCadastroMesa(repositorioMesa, notificador);

            repositorioProduto = new RepositorioProduto();
            telaCadastoProduto = new TelaCadastroProduto(repositorioProduto, notificador);

            repositorioPedido = new RepositorioPedido();
            telaCadastoPedido = new TelaCadastroPedido(repositorioPedido, notificador);

            //PopularAplicacao();
        }

        public string MostrarOpcoes()
        {
            Console.Clear();

            Console.WriteLine("Controle de Mesas de Bar 2.0");

            Console.WriteLine();

            Console.WriteLine("[1] Gerenciar Garçons");

            Console.WriteLine("[2] Gerenciar Mesas");

            Console.WriteLine("[3] Gerenciar Pedidos");

            Console.WriteLine("[4] Gerenciar Produtos");

            Console.WriteLine("[s] para sair");

            string opcaoSelecionada = Console.ReadLine();

            return opcaoSelecionada;
        }

        public TelaBase ObterTela()
        {
            string opcao = MostrarOpcoes();

            TelaBase tela = null;

            if (opcao == "1")
                tela = telaCadastroGarcom;

            else if (opcao == "2")
                tela = telaCadastroMesa;

            else if (opcao == "3")
                tela = telaCadastoPedido;

            else if (opcao == "4")
                tela = telaCadastoProduto;

            else if (opcao == "5")
                tela = null;

            return tela;
        }

        //private void PopularAplicacao()
        //{
        //    var garcom = new Garcom("Julinho", "230.232.519-98");
        //    repositorioGarcom.Inserir(garcom);
        //}
    }
}
