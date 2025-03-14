using FilmesAPI.Resources;
using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Data.DTOs;

public class UpdateEnderecoDto
{
    [Required(ErrorMessageResourceName = "LogradouroRequired", ErrorMessageResourceType = typeof(EnderecoStrings))]
    public string Logradouro { get; set; }

    public string Numero { get; set; }
}
