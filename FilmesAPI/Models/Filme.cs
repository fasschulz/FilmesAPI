using FilmesAPI.Resources;
using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Models;

public class Filme
{
    [Key]
    [Required]
    public int Id { get; set; }

    [Required(ErrorMessageResourceName = "TituloRequired", ErrorMessageResourceType = typeof(FilmeStrings))]
    public required string Titulo { get; set; }

    [Required(ErrorMessageResourceName = "GeneroRequired", ErrorMessageResourceType = typeof(FilmeStrings))]
    [MaxLength(50, ErrorMessageResourceName = "GeneroMaxLength", ErrorMessageResourceType = typeof(FilmeStrings))]
    public required string Genero { get; set; }

    [Required(ErrorMessageResourceName = "DuracaoRequired", ErrorMessageResourceType = typeof(FilmeStrings))]
    [Range(70, 600, ErrorMessageResourceName = "DuracaoRange", ErrorMessageResourceType = typeof(FilmeStrings))]
    public int Duracao { get; set; }

    public virtual ICollection<Sessao> Sessoes { get; set; }
}
