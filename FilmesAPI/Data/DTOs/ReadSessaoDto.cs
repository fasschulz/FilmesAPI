using FilmesAPI.Models;

namespace FilmesAPI.Data.DTOs;

public class ReadSessaoDto
{
    public int FilmeId { get; set; }
    public string Filme { get; set; }
    public int CinemaId { get; set; }
    public string Cinema { get; set; }
}
