using System;
using System.ComponentModel.DataAnnotations;

namespace Nota.application.Dto;

public class TarefaCadastro
{
    [Required(ErrorMessage = "{0}: É obrigatório")]
    [StringLength(50, ErrorMessage = "{0}: Maximo de 50 caracteres")]
    public required string Titulo { get; set; }
    
    [Required(ErrorMessage = "{0}: É obrigatório")]
    public required string BlocoInformacao { get; set; }
}
