using apiToDo.Domain.Dto;
using apiToDo.Domain.Models;
using System.Collections.Generic;

namespace apiToDo.Domain.Interfaces.Services
{
    public interface ITarefaService
    {
        void InserirTarefa(Tarefa tarefa);
        List<TarefaDto> ListarTarefas();
        void DeletarTarefa(int id);
        TarefaDto? ObterTarefa(int id);
        void AlterarTarefa(TarefaDto tarefaDto);
    }
}
