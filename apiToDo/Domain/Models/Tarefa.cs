using apiToDo.Domain.Dto;
using System;

namespace apiToDo.Domain.Models
{
    public class Tarefa
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public DateTime DataDoRegistro { get; set; }

        /// <summary>
        /// conversao implicita de tarefa dto para tarefa
        /// </summary>
        /// <param name="tarefa"></param>
        public static implicit operator Tarefa(TarefaDto tarefa)
        {
            return new Tarefa
            {
                Id = tarefa.Id,
                Nome = tarefa.Nome,
                DataDoRegistro = DateTime.Now
            };
        }
    }
}