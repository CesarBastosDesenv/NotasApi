using System;
using Nota.application.Dto;
using Nota.application.Interfaces;
using Nota.Domain.Models;
using Nota.Infra.Data.Interfaces;

namespace Nota.application.Services;

public class TarefaService : ITarefaService
{
private ITarefaRepository _tarefaRepository;

    public TarefaService(ITarefaRepository tarefaRepository)
    {
        _tarefaRepository = tarefaRepository;
       
    }

    public async Task<ResultViewModel> AddAsync(TarefaCadastro args)
    {
        var tarefa = new Tarefa()
        {
            Titulo = args.Titulo,
            BlocoInformacao = args.BlocoInformacao
        };
        _tarefaRepository.AdicionarTarefa(tarefa);
        var result = new ResultViewModel(await _tarefaRepository.SaveChangesAsync());
       
        if (!(bool)result.Data)
            result.AddNotification("", "Erro ao cadastrar");

        return result; 
    }

    public async Task<ResultViewModel> BuscaTarefaId(Guid Id)
    {
        return new ResultViewModel(await _tarefaRepository.BuscaTarefaId(Id));
    }

    public async Task<PagedList> GetAllAsync(int pageNumber, int pageSize)
    {
        var retorno = await _tarefaRepository.BuscaTarefa(pageNumber, pageSize);
         var retornoModel = retorno.Select(x => new TarefaView(){
            Id = x.Id,
            Titulo = x.Titulo,
            BlocoInformacao = x.BlocoInformacao
            });
        return new PagedList() {Data = retornoModel, TotalCount = retorno.TotalCount};
    }

    public Task<ResultViewModel> UpdateAsync(TarefaCadastro tarefa)
    {
        throw new NotImplementedException();
    }
}
