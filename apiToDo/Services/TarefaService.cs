using apiToDo.Domain.Dto;
using apiToDo.Domain.Interfaces.Repositories;
using apiToDo.Domain.Interfaces.Services;
using apiToDo.Domain.Models;
using apiToDo.Exceptions;
using System.Collections.Generic;
using System.Linq;


namespace apiToDo.Service
{
    public class TarefaService : ITarefaService
    {
        private readonly ITarefaRepository _tarefaRepository;
        public TarefaService(ITarefaRepository tarefaRepository)
        {
            _tarefaRepository = tarefaRepository;
        }

        public void InserirTarefa(Tarefa tarefa)
        {
            _tarefaRepository.InserirTarefa(tarefa);
        }

        public List<TarefaDto> ListarTarefas()
        {
            return _tarefaRepository.ListarTarefa().Select(ta => (TarefaDto)ta).ToList();
        }

        public void DeletarTarefa(int id)
        {
            // obter tarefa para exclusão
            var tarefa = ObterTarefa(id);

            // excluir tarefa da lista
            _tarefaRepository.DeletarTarefa(tarefa);
        }

        public TarefaDto ObterTarefa(int id)
        {
            var tarefa = _tarefaRepository.ObterTarefa(id);

            //verificando se a tarefa foi encontrada na lista
            if (tarefa == null)
            {
                // dispara uma exceção caso a tarefa nao exista
                throw new NotFoundExceptions($"Tarefa de Id {id} não encontrada.");
            }
            return tarefa;
        }

        public void AlterarTarefa(TarefaDto tarefaDto)
        {
            // verificando se a tarefa existe
            ObterTarefa(tarefaDto.Id);
            _tarefaRepository.AlterarTarefa(tarefaDto);
        }
    }
}
