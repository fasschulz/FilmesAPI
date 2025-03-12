using FilmesAPI.Resources;
using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Data.DTOs;

public class CreateFilmeDto
{
    [Required(ErrorMessageResourceName = "TituloRequired", ErrorMessageResourceType = typeof(FilmeStrings))]
    public required string Titulo { get; set; }

    [Required(ErrorMessageResourceName = "GeneroRequired", ErrorMessageResourceType = typeof(FilmeStrings))]
    [MaxLength(50, ErrorMessageResourceName = "GeneroMaxLength", ErrorMessageResourceType = typeof(FilmeStrings))]
    public required string Genero { get; set; }

    [Required(ErrorMessageResourceName = "DuracaoRequired", ErrorMessageResourceType = typeof(FilmeStrings))]
    [Range(70, 600, ErrorMessageResourceName = "DuracaoRange", ErrorMessageResourceType = typeof(FilmeStrings))]
    public int Duracao { get; set; }
}
