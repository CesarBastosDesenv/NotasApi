using System;

namespace Nota.Domain.Models;

public class Nota
{
    public Guid Id { get; set; }
    public required string Titulo { get; set; }   
    public required string BlocoInformacao { get; set; }    
 
}
