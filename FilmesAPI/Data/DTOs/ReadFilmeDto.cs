using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Data.DTOs;

public class ReadFilmeDto
{
    public required string Titulo { get; set; }
        
    public required string Genero { get; set; }
        
    public int Duracao { get; set; }

    public DateTime HoraDaConsulta { get; set; } = DateTime.Now;
}
