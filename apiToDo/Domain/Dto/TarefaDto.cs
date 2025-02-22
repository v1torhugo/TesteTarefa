using apiToDo.Domain.Models;

namespace apiToDo.Domain.Dto
{
    public class TarefaDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public static implicit operator TarefaDto(Tarefa tarefa)
        {
            return new TarefaDto
            {
                Id = tarefa.Id,
                Nome = tarefa.Nome
            };
        }
    }
}
