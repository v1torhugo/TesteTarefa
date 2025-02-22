using apiToDo.Domain.Models;
using System.Collections.Generic;

namespace apiToDo.Domain.Interfaces.Repositories
{
    public interface ITarefaRepository
    {
        void InserirTarefa(Tarefa tarefa);
        List<Tarefa> ListarTarefa();
        void DeletarTarefa(Tarefa tarefa);
        Tarefa? ObterTarefa(int id);
        void AlterarTarefa(Tarefa tarefa);
    }
}
