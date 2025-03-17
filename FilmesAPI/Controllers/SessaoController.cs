using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using FilmesAPI.Data.DTOs;
using FilmesAPI.Data;
using FilmesAPI.Models;
using Microsoft.EntityFrameworkCore;
using FilmesAPI.Profiles;

namespace FilmesApi.Controllers;

[ApiController]
[Route("[controller]")]
public class SessaoController : ControllerBase
{
    private FilmeContext _context;
    private IMapper _mapper;

    public SessaoController(FilmeContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult AdicionaSessao(CreateSessaoDto dto)
    {
        Sessao sessao = _mapper.Map<Sessao>(dto);
        _context.Sessoes.Add(sessao);
        _context.SaveChanges();

        return CreatedAtAction(nameof(RecuperaSessoesPorId), 
            new { filmeId = sessao.FilmeId, cinemaId = sessao.CinemaId }, dto);
    }

    [HttpGet]
    public IEnumerable<ReadSessaoDto> RecuperaSessoes()
    {
        return _mapper.Map<List<ReadSessaoDto>>(_context.Sessoes.ToList());
    }

    [HttpGet("{filmeId}/{cinemaId}")]
    public IActionResult RecuperaSessoesPorId(int filmeId, int cinemaId)
    {
        Sessao? sessao = _context.Sessoes.FirstOrDefault(sessao => 
        sessao.FilmeId == filmeId && sessao.CinemaId == cinemaId);

        if (sessao != null)
        {
            ReadSessaoDto sessaoDto = _mapper.Map<ReadSessaoDto>(sessao);

            return Ok(sessaoDto);
        }
        return NotFound();
    }

    [HttpDelete("{filmeId}/{cinemaId}")]
    public IActionResult DeletaSessao(int filmeId, int cinemaId)
    {
        var sessao = _context.Sessoes
            .Where(s => s.FilmeId == filmeId && s.CinemaId == cinemaId)
            .FirstOrDefault();

        if (sessao == null)
            return NotFound();

        _context.Remove(sessao);
        _context.SaveChanges();
        return NoContent();
    }
}