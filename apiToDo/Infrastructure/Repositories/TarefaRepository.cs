using apiToDo.Domain.Interfaces.Repositories;
using apiToDo.Domain.Models;
using System.Collections.Generic;
using System.Linq;

namespace apiToDo.Infrastructure.Repositories
{
    /// <summary>
    /// Repositorio responsavel por manter as operações da tarefa, gravando resultado numa lista memoria 
    /// </summary>
    public class TarefaRepository : ITarefaRepository
    {
        private readonly List<Tarefa> _listaTarefa;
        public TarefaRepository()
        {
            _listaTarefa = new List<Tarefa>();
        }

        /// <summary>
        /// metodo responsavel por inserir na lista 
        /// </summary>
        /// <param name="tarefa"></param>
        public void InserirTarefa(Tarefa tarefa)
        {
            _listaTarefa.Add(tarefa);
        }

        /// <summary>
        /// metodo responsavel por listas tarefa
        /// </summary>
        /// <returns></returns>
        public List<Tarefa> ListarTarefa()
        {
            return _listaTarefa;
        }

        /// <summary>
        /// metodo responsavel por deletar na lista
        /// </summary>
        /// <param name="tarefa"></param>
        public void DeletarTarefa(Tarefa tarefa)
        {
            _listaTarefa.Remove(tarefa);

        }

        /// <summary>
        /// metodo responsavel por obter tarefa na lista
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Tarefa? ObterTarefa(int id)
        {
            return _listaTarefa.FirstOrDefault(x => x.Id == id);
        }

        public void AlterarTarefa(Tarefa tarefa)
        {
            var tarefaLista = _listaTarefa.FirstOrDefault(x => x.Id == tarefa.Id);

            tarefaLista.Nome = tarefa.Nome;
            tarefaLista.DataDoRegistro = tarefa.DataDoRegistro;
        }
    }
}
