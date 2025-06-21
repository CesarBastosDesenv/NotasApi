using System;
using Microsoft.EntityFrameworkCore;
using Nota.Domain.Models;
using Nota.Domain.Pagination;
using Nota.Infra.Data.Context;
using Nota.Infra.Data.Helpers;
using Nota.Infra.Data.Interfaces;

namespace Nota.Infra.Data.Repositories;

public class TarefaRepository : ITarefaRepository
{
private readonly ApiContext _context;

         public TarefaRepository(ApiContext context)
        {
            _context = context;
        }

    public void AdicionarTarefa(Tarefa tarefa)
    {
        _context.Add(tarefa);
    }

    public void AtualizarTarefa(Tarefa tarefa)
    {
        _context.Update(tarefa);
    }

    public async Task<Tarefa> BuscaTarefaId(Guid Id)
    {
        return await _context.Tarefas.
                       Where(x => x.Id == Id).FirstOrDefaultAsync();
    }

    public async Task<PagedList<Tarefa>> BuscaTarefa(int pageNumber, int pageSize)
    {
        var query = _context.Tarefas.AsQueryable();
        return await PaginationHelper.CreateAsync(query, pageNumber, pageSize);
    }

    public void DeletarTarefa(Tarefa tarefa)
    {
        _context.Remove(tarefa);
    }

    public async Task<bool> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync() > 0;
    }
}
