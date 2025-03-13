﻿using FilmesAPI.Resources;
using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Models;

public class Cinema
{
    [Key]
    [Required]
    public int Id { get; set; }

    [Required(ErrorMessageResourceName = "NomeRequired", ErrorMessageResourceType = typeof(CinemaStrings))]
    public string Nome { get; set; }
}
