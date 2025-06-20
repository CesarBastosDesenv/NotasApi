using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nota.Domain.Models;

namespace Nota.Infra.Data.Mappings;

public class TarefaMap : IEntityTypeConfiguration<Tarefa>
{
    public void Configure(EntityTypeBuilder<Tarefa> builder)
    {
        builder.ToTable("Tarefas");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Titulo)
        .IsRequired()
        .HasColumnType("varchar(50)"); 
        
        builder.Property(x => x.BlocoInformacao)
        .IsRequired()
        .HasColumnType("varchar(255)");

            }
}
