using ControleBar.ConsoleApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleBar.ConsoleApp.ModuloProduto
{
    internal class TelaCadastroProduto : TelaBase, ITelaCadastravel
    {
        private readonly IRepositorio<Produto> _repositorioProduto;
        private readonly Notificador _notificador;

        public TelaCadastroProduto(IRepositorio<Produto> repositorioProduto, Notificador notificador)
            : base("Cadastro de Produtos")
        {
            _repositorioProduto = repositorioProduto;
            _notificador = notificador;
        }

        public void Inserir()
        {
            MostrarTitulo("Cadastro de Produtos");

            Produto novoProduto = obterProduto();

            _repositorioProduto.Inserir(novoProduto);

            _notificador.ApresentarMensagem("Produto cadastrado com sucesso!", TipoMensagem.Sucesso);
        }

        public void Editar()
        {
            MostrarTitulo("Editando Produtos");

            bool temRegistrosCadastrados = VisualizarRegistros("Pesquisando");

            if (temRegistrosCadastrados == false)
            {
                _notificador.ApresentarMensagem("Nenhum produto cadastrado para editar.", TipoMensagem.Atencao);
                return;
            }

            int numeroGenero = ObterNumeroRegistro();

            Produto produtoAtualizado = obterProduto();

            bool conseguiuEditar = _repositorioProduto.Editar(numeroGenero, produtoAtualizado);

            if (!conseguiuEditar)
                _notificador.ApresentarMensagem("Não foi possível editar.", TipoMensagem.Erro);
            else
                _notificador.ApresentarMensagem("Produto editado com sucesso!", TipoMensagem.Sucesso);
        }

        public void Excluir()
        {
            MostrarTitulo("Excluindo Produtos");

            bool temFuncionariosRegistrados = VisualizarRegistros("Pesquisando");

            if (temFuncionariosRegistrados == false)
            {
                _notificador.ApresentarMensagem("Nenhum produto cadastrado para excluir.", TipoMensagem.Atencao);
                return;
            }

            int numeroProduto = ObterNumeroRegistro();

            bool conseguiuExcluir = _repositorioProduto.Excluir(numeroProduto);

            if (!conseguiuExcluir)
                _notificador.ApresentarMensagem("Não foi possível excluir.", TipoMensagem.Erro);
            else
                _notificador.ApresentarMensagem("Produto excluído com sucesso!", TipoMensagem.Sucesso);
        }

        public bool VisualizarRegistros(string tipoVisualizacao)
        {
            if (tipoVisualizacao == "Tela")
                MostrarTitulo("Visualização de Produtos Cadastrados");

            List<Produto> produtos = _repositorioProduto.SelecionarTodos();

            if (produtos.Count == 0)
            {
                _notificador.ApresentarMensagem("Nenhum produto disponível.", TipoMensagem.Atencao);
                return false;
            }

            foreach (Produto garcom in produtos)
                Console.WriteLine(garcom.ToString());

            Console.ReadLine();

            return true;
        }

        private Produto obterProduto()
        {
            Console.Write("Digite o nome do produto: ");
            string nome = Console.ReadLine();

            return new Produto(nome);
        }

        public int ObterNumeroRegistro()
        {
            int numeroRegistro;
            bool numeroRegistroEncontrado;

            do
            {
                Console.Write("Digite o ID do produto que deseja selecionar: ");
                numeroRegistro = Convert.ToInt32(Console.ReadLine());

                numeroRegistroEncontrado = _repositorioProduto.ExisteRegistro(numeroRegistro);

                if (numeroRegistroEncontrado == false)
                    _notificador.ApresentarMensagem("ID do produto não foi encontrado, digite novamente", TipoMensagem.Atencao);

            } while (numeroRegistroEncontrado == false);

            return numeroRegistro;
        }
    }
}
