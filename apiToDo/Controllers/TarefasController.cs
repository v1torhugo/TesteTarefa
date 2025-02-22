using apiToDo.Domain.Dto;
using apiToDo.Domain.Interfaces.Services;
using apiToDo.Exceptions;
using Microsoft.AspNetCore.Mvc;
using System;

namespace apiToDo.Controllers
{
    [ApiController]
    [Route("api/tarefas")]
    public class TarefasController : ControllerBase
    {
        private readonly ITarefaService _tarefasService;

        public TarefasController(ITarefaService tarefasService)
        {
            _tarefasService = tarefasService;
        }

        [HttpGet("ObterTarefa/{id}")]
        public IActionResult Obtertarefa(int id)
        {
            try
            {
                var tarefa = _tarefasService.ObterTarefa(id);
                return Ok(tarefa);
            }
            catch (NotFoundExceptions ex)
            {
                return NotFound(new { mensagem = $"Erro: {ex.Message}." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { mensagem = $"Ocorreu um erro ao tentar obter a tarefa. Erro:{ex.Message}" });
            }
        }

        [HttpGet("ListarTarefas")]
        public IActionResult listarTarefas()
        {
            var tarefas = _tarefasService.ListarTarefas();
            return Ok(tarefas);
        }

        [HttpPost("InserirTarefa")]
        public IActionResult InserirTarefa([FromBody] TarefaDto tarefaDto)
        {
            _tarefasService.InserirTarefa(tarefaDto);
            return NoContent();
        }

        [HttpDelete("DeletarTarefa/{id}")]
        public IActionResult DeletarTarefa(int id)
        {
            try
            {
                _tarefasService.DeletarTarefa(id);

                return Ok(new { mensagem = "Tarefa deletada com sucesso." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { mensagem = $"Ocorreu um erro ao tentar deletar a tarefa. Erro:{ex.Message}" });
            }
        }

        [HttpPut("AlterarTarefa")]
        public IActionResult AlterarTarefa([FromBody] TarefaDto tarefaDto)
        {
            try
            {
                _tarefasService.AlterarTarefa(tarefaDto);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { mensagem = $"Ocorreu um erro ao tentar alterar a tarefa. Erro:{ex.Message}" });
            }
        }
    }

}

