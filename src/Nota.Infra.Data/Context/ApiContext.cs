using System;
using Nota.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Nota.Infra.Data.Context;

public class ApiContext : DbContext
{
    public ApiContext(DbContextOptions<ApiContext> options) : base(options)
    {

    }

      public DbSet<Tarefa> Tarefas { get; set; }
}
