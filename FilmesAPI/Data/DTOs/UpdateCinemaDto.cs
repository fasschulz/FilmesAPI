using FilmesAPI.Resources;
using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Data.DTOs;

public class UpdateCinemaDto
{
    [Required(ErrorMessageResourceName = "NomeRequired", ErrorMessageResourceType = typeof(CinemaStrings))]
    public string Nome { get; set; }
}
