using FilmesAPI.Resources;
using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Models;

public class Endereco
{
    [Key]
    [Required]
    public int Id { get; set; }

    [Required(ErrorMessageResourceName = "LogradouroRequired", ErrorMessageResourceType = typeof(EnderecoStrings))]
    public string Logradouro { get; set; }

    public string Numero { get; set; }

    public virtual Cinema Cinema { get; set; }
}
