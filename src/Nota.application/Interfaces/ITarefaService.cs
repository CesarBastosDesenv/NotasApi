using System;
using Nota.application.Dto;


namespace Nota.application.Interfaces;

public interface ITarefaService
{
    Task<ResultViewModel> AddAsync(TarefaCadastro tarefa);

    Task<ResultViewModel> UpdateAsync(TarefaCadastro tarefa);

    Task<PagedList> GetAllAsync(int pageNumber, int pageSize);

    Task<ResultViewModel> BuscaTarefaId(Guid Id);
}
