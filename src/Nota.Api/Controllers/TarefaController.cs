using System;
using Microsoft.AspNetCore.Mvc;
using Nota.Api.Extensions;
using Nota.Api.Models;
using Nota.application.Dto;
using Nota.application.Interfaces;

namespace Nota.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TarefaController : ControllerBase
{
    private ILogger<TarefaController> _logger;
    private ITarefaService _tarefaService;

    public TarefaController(ILogger<TarefaController> logger, ITarefaService tarefaService)
    {
        _logger = logger;
        _tarefaService = tarefaService;
    }

    [HttpGet]
    public async Task<ActionResult> Get([FromQuery]PaginationParams paginationParams)
    {
        try
        {
            var result = await _tarefaService.GetAllAsync(paginationParams.PageNumber,paginationParams.PageSize);
            Response.AddPaginationHeader(new PaginationHeader(result.CurrentPage, result.PageSize, result.TotalCount, result.TotalPages));
            return Ok(result);
        }
        catch (Exception ex)
        {
            var er = new ResultViewModel();
            er.AddNotification("Erro", ex.Message);
            return BadRequest(er);
        }
    } 
    [HttpGet("{Id}")]
    public async Task<ActionResult> Get(Guid Id)
    {
       try
        {
            var result = await _tarefaService.BuscaTarefaId(Id);
            return Ok(result);
        }
        catch (Exception ex)
        {
            var er = new ResultViewModel();
            er.AddNotification("Erro", ex.Message);
            return BadRequest(er);
        } 
    }

    [HttpPost]
    public async Task<ActionResult> Add(TarefaCadastro args)
    {
        try
        {
            if (!ModelState.IsValid) return Ok(new ResultViewModel(args, ModelState));
            var result = await _tarefaService.AddAsync(args);
            return Ok(result);
        }
        catch (Exception ex)
        {
            var er = new ResultViewModel();
            er.AddNotification("Erro", ex.Message);
            return BadRequest(er);
        }
    }

}
