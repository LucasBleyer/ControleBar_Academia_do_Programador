using ControleBar.ConsoleApp.Compartilhado;
using System.Collections.Generic;
using System;
using ControleBar.ConsoleApp.ModuloProduto;

namespace ControleBar.ConsoleApp.ModuloPedido
{
    internal class TelaCadastroPedido : TelaBase, ITelaCadastravel
    {
        private readonly IRepositorio<Pedido> _repositorioPedido;
        private readonly Notificador _notificador;

        public TelaCadastroPedido(IRepositorio<Pedido> repositorioPedido, Notificador notificador)
            : base("Cadastro de Pedidos")
        {
            _repositorioPedido = repositorioPedido;
            _notificador = notificador;
        }

        public void Inserir()
        {
            MostrarTitulo("Cadastro de Pedidos");

            Pedido novoPedido = obterPedido();

            _repositorioPedido.Inserir(novoPedido);

            _notificador.ApresentarMensagem("Pedido cadastrado com sucesso!", TipoMensagem.Sucesso);
        }

        public void Editar()
        {
            MostrarTitulo("Editando Pedido");

            bool temRegistrosCadastrados = VisualizarRegistros("Pesquisando");

            if (temRegistrosCadastrados == false)
            {
                _notificador.ApresentarMensagem("Nenhum pedido cadastrado para editar.", TipoMensagem.Atencao);
                return;
            }

            int numeroGenero = ObterNumeroRegistro();

            Pedido pedidoAtualizado = obterPedido();

            bool conseguiuEditar = _repositorioPedido.Editar(numeroGenero, pedidoAtualizado);

            if (!conseguiuEditar)
                _notificador.ApresentarMensagem("Não foi possível editar.", TipoMensagem.Erro);
            else
                _notificador.ApresentarMensagem("Pedido editado com sucesso!", TipoMensagem.Sucesso);
        }

        public void Excluir()
        {
            MostrarTitulo("Excluindo Pedido");

            bool temPedidosRegistrados = VisualizarRegistros("Pesquisando");

            if (temPedidosRegistrados == false)
            {
                _notificador.ApresentarMensagem("Nenhum pedido cadastrado para excluir.", TipoMensagem.Atencao);
                return;
            }

            int numeroGarcom = ObterNumeroRegistro();

            bool conseguiuExcluir = _repositorioPedido.Excluir(numeroGarcom);

            if (!conseguiuExcluir)
                _notificador.ApresentarMensagem("Não foi possível excluir.", TipoMensagem.Erro);
            else
                _notificador.ApresentarMensagem("Pedido excluído com sucesso!", TipoMensagem.Sucesso);
        }

        public bool VisualizarRegistros(string tipoVisualizacao)
        {
            if (tipoVisualizacao == "Tela")
                MostrarTitulo("Visualização de Pedidos Cadastrados");

            List<Pedido> pedidos = _repositorioPedido.SelecionarTodos();

            if (pedidos.Count == 0)
            {
                _notificador.ApresentarMensagem("Nenhum pedido disponível.", TipoMensagem.Atencao);
                return false;
            }

            foreach (Pedido pedido in pedidos)
                Console.WriteLine(pedido.ToString());

            Console.ReadLine();

            return true;
        }

        private Pedido obterPedido()
        {
            Console.Write("Digite o número do pedido: ");
            int numero = Convert.ToInt32(Console.ReadLine());

            List<Produto> produtos = new List<Produto>();
            foreach (Produto produto in produtos)
            {
                Console.WriteLine("O que o cliente deseja? ");
                produtos.Add(produto);
            }

            return new Pedido(numero, produtos);
        }

        public int ObterNumeroRegistro()
        {
            int numeroRegistro;
            bool numeroRegistroEncontrado;

            do
            {
                Console.Write("Digite o ID do pedido que deseja selecionar: ");
                numeroRegistro = Convert.ToInt32(Console.ReadLine());

                numeroRegistroEncontrado = _repositorioPedido.ExisteRegistro(numeroRegistro);

                if (numeroRegistroEncontrado == false)
                    _notificador.ApresentarMensagem("ID do pedido não foi encontrado, digite novamente", TipoMensagem.Atencao);

            } while (numeroRegistroEncontrado == false);

            return numeroRegistro;
        }
    }
}
