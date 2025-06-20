using System;
using Nota.Domain.Models;
using Nota.Domain.Pagination;

namespace Nota.Infra.Data.Interfaces;

public interface ITarefaRepository
{
    Task<PagedList<Tarefa>> BuscaVeiculo(int pageNumber, int pageSize);
    Task<Tarefa> BuscaTarefaId(Guid Id);
    void AdicionarTarefa(Tarefa tarefa);
    void AtualizarTarefa(Tarefa tarefa);
    void DeletarTarefa(Tarefa tarefa);

    Task<bool> SaveChangesAsync();
}
