using Senai.Senatur.WebApi.DatabaseFirst.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Senatur.WebApi.DatabaseFirst.Interfaces
{
    interface IPacoteRepository
    {
        /// <summary>
        /// listar todos os pacotes
        /// </summary>
        /// <returns>uma lista com todos os pacotes</returns>
        List<Pacotes> Listar();

        /// <summary>
        /// busca um pacote pelo id
        /// </summary>
        /// <param name="id"></param>
        /// <returns> o pacote buscado </returns>
        Pacotes BuscarPorId(int id);


        /// <summary>
        /// cadastrar pacotes
        /// </summary>
        /// <param name="id"></param>
        /// <param name="novoPacote"></param>
        void Cadastrar(Pacotes novoPacote);

        /// <summary>
        /// atualiza pacotes
        /// </summary>
        /// <param name="id"></param>
        /// <param name="pacoteAtualizado"></param>
        void Atualizar(int id, Pacotes pacoteAtualizado);

        /// <summary>
        /// deleta pacotes
        /// </summary>
        /// <param name="id"></param>
        void Deletar(int id);

        List<Pacotes> PacotesAtivos(bool pacotesAtivos);

        List<Pacotes> ListarOrdenado(string ordem);
    }
}
