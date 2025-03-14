using FilmesAPI.Resources;
using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Data.DTOs;

public class CreateCinemaDto
{
    [Required(ErrorMessageResourceName = "NomeRequired", ErrorMessageResourceType = typeof(CinemaStrings))]
    public string Nome { get; set; }

    public int EnderecoId { get; set; }
}
