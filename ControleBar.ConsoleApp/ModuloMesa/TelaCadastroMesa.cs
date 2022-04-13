using ControleBar.ConsoleApp.Compartilhado;
using System.Collections.Generic;
using System;

namespace ControleBar.ConsoleApp.ModuloMesa
{
    internal class TelaCadastroMesa : TelaBase, ITelaCadastravel
    {
        private readonly IRepositorio<Mesa> _repositorioMesa;
        private readonly Notificador _notificador;

        public TelaCadastroMesa(IRepositorio<Mesa> repositorioMesa, Notificador notificador)
            : base("Cadastro de Mesas")
        {
            _repositorioMesa = repositorioMesa;
            _notificador = notificador;
        }

        public void Inserir()
        {
            MostrarTitulo("Cadastro de Mesas");

            Mesa novaMesa = ObterMesa();

            _repositorioMesa.Inserir(novaMesa);

            _notificador.ApresentarMensagem("Mesa cadastrada com sucesso!", TipoMensagem.Sucesso);
        }

        public void Editar()
        {
            MostrarTitulo("Editando Mesas");

            bool temMesasCadastradas = VisualizarRegistros("Pesquisando");

            if (temMesasCadastradas == false)
            {
                _notificador.ApresentarMensagem("Nenhuma mesa cadastrada para editar.", TipoMensagem.Atencao);
                return;
            }

            int numeroGenero = ObterNumeroRegistro();

            Mesa mesaAtualizada = ObterMesa();

            bool conseguiuEditar = _repositorioMesa.Editar(numeroGenero, mesaAtualizada);

            if (!conseguiuEditar)
                _notificador.ApresentarMensagem("Não foi possível editar.", TipoMensagem.Erro);
            else
                _notificador.ApresentarMensagem("Mesa editada com sucesso!", TipoMensagem.Sucesso);
        }

        public void Excluir()
        {
            MostrarTitulo("Excluindo Mesas");

            bool temMesasCadastradas = VisualizarRegistros("Pesquisando");

            if (temMesasCadastradas == false)
            {
                _notificador.ApresentarMensagem("Nenhuma mesa cadastrada para excluir.", TipoMensagem.Atencao);
                return;
            }

            int numeroMesa = ObterNumeroRegistro();

            bool conseguiuExcluir = _repositorioMesa.Excluir(numeroMesa);

            if (!conseguiuExcluir)
                _notificador.ApresentarMensagem("Não foi possível excluir.", TipoMensagem.Erro);
            else
                _notificador.ApresentarMensagem("Mesa excluída com sucesso!", TipoMensagem.Sucesso);
        }

        public bool VisualizarRegistros(string tipoVisualizacao)
        {
            if (tipoVisualizacao == "Tela")
                MostrarTitulo("Visualização de Mesas Cadastradas");

            List<Mesa> mesas = _repositorioMesa.SelecionarTodos();

            if (mesas.Count == 0)
            {
                _notificador.ApresentarMensagem("Nenhuma mesa disponível.", TipoMensagem.Atencao);
                return false;
            }

            foreach (Mesa mesa in mesas)
                Console.WriteLine(mesas.ToString());

            Console.ReadLine();

            return true;
        }

        private Mesa ObterMesa()
        {
            Console.Write("Digite o número da mesa: ");
            int numero = Convert.ToInt32(Console.ReadLine());

            return new Mesa(numero);
        }

        public int ObterNumeroRegistro()
        {
            int numeroRegistro;
            bool numeroRegistroEncontrado;

            do
            {
                Console.Write("Digite o numero da mesa que deseja selecionar: ");
                numeroRegistro = Convert.ToInt32(Console.ReadLine());

                numeroRegistroEncontrado = _repositorioMesa.ExisteRegistro(numeroRegistro);

                if (numeroRegistroEncontrado == false)
                    _notificador.ApresentarMensagem("ID da mesa não foi encontrado, digite novamente", TipoMensagem.Atencao);

            } while (numeroRegistroEncontrado == false);

            return numeroRegistro;
        }
    }
}
