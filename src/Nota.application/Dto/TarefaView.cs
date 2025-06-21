using System;

namespace Nota.application.Dto;

public class TarefaView
{
    public Guid Id { get; set; }
    public required string Titulo { get; set; }

    public required string BlocoInformacao { get; set; }
}
