using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Models;

public class Filme
{
    [Key]
    [Required]
    public int Id { get; set; }

    [Required(ErrorMessage = "O Título do filme é obrigatório")]
    public required string Titulo { get; set; }

    [Required(ErrorMessage = "O Gênero do filme é obrigatório")]
    [MaxLength(50, ErrorMessage = "O tamanho do gênero não pode exceder 50 caracteres")]
    public required string Genero { get; set; }

    [Required(ErrorMessage = "A Duração do filme é obrigatória")]
    [Range(70, 600, ErrorMessage = "A Duração deve ter entre 70 e 600 minutos")]
    public int Duracao { get; set; }    
}
