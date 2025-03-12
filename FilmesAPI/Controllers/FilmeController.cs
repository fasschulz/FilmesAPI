using FilmesAPI.Data;
using FilmesAPI.Data.DTOs;
using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;

namespace FilmesAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class FilmeController : ControllerBase
{
    private FilmeContext _context;
    private IMapper _mapper;

    public FilmeController(FilmeContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    /// <summary>
    /// Adiciona um filme ao banco de dados
    /// </summary>
    /// <param name="filmeDto">Objeto com os campos necessários para criação de um filme</param>
    /// <returns>IActionResult</returns>
    /// <response code="201">Caso inserção seja feita com sucesso</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public IActionResult AdicionaFilme([FromBody] CreateFilmeDto filmeDto)
    {
        Filme filme = _mapper.Map<Filme>(filmeDto);
        _context.Filmes.Add(filme);
        _context.SaveChanges();
        return CreatedAtAction(nameof(RecuperaFilmePorId), new { id = filme.Id }, filme);
    }

    /// <summary>
    /// Retorna a lista de todos os filmes cadastrados no banco de dados
    /// </summary>
    /// <param name="skip">Quantos itens você deseja pular na paginação</param>
    /// <param name="take">Quantos itens você deseja obter em cada página</param>
    /// <returns>IEnumerable</returns>
    /// <response code="200">Caso traga todos os itens com sucesso</response>
    [HttpGet]
    public IEnumerable<ReadFilmeDto> RecuperaFilmes([FromQuery] int skip = 0,
                                             [FromQuery] int take = 50)
    {
        var filmes = _context.Filmes.Skip(skip).Take(take);
        return _mapper.Map<List<ReadFilmeDto>>(filmes);        
    }

    /// <summary>
    /// Retorna o filme de acordo com seu ID
    /// </summary>
    /// <param name="id">ID do filme que deseja obter</param>    
    /// <returns>IActionResult</returns>
    /// <response code="200">Caso traga o filme com sucesso</response>
    [HttpGet("{id}")]
    public IActionResult RecuperaFilmePorId(int id)
    {
        var filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
        if (filme == null) return NotFound();

        var filmeDto = _mapper.Map<ReadFilmeDto>(filme);

        return Ok(filmeDto);
    }

    /// <summary>
    /// Atualização completa de todos os campos de um filme
    /// </summary>
    /// <param name="id">ID do filme que deseja atualizar</param>
    /// <param name="filmeDto">Objeto com os campos necessários para a atualização de um filme</param>
    /// <returns>IActionResult</returns>
    /// <response code="204">Caso atualize o filme com sucessso</response>
    [HttpPut("{id}")]
    public IActionResult AtualizaFilme(int id, [FromBody] UpdateFilmeDto filmeDto)
    {
        var filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);

        if (filme == null) return NotFound();

        _mapper.Map(filmeDto, filme);
        _context.SaveChanges();

        return NoContent();
    }

    /// <summary>
    /// Atualização parcial de campos específicos de um filme
    /// </summary>
    /// <param name="id">ID do filme que deseja atualizar</param>
    /// <remarks>
    /// <param name="patch">JSON com os campos necessários para a atualização parcial de um filme</param> \
    /// op -> replace \
    /// path -> indica qual campo de objeto quer atualizar \
    /// value -> conteúdo que deseja atualizar no campo
    /// </remarks>    
    /// <returns>IActionResult</returns>
    /// <response code="204">Caso atualize o filme com sucessso</response>
    [HttpPatch("{id}")]
    public IActionResult AtualizaFilmeParcial(int id, JsonPatchDocument<UpdateFilmeDto> patch)
    {
        var filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
        if (filme == null) return NotFound();

        var filmeParaAtualizar = _mapper.Map<UpdateFilmeDto>(filme);
        patch.ApplyTo(filmeParaAtualizar, ModelState);

        if (!TryValidateModel(filmeParaAtualizar))
            return ValidationProblem(ModelState);

        _mapper.Map(filmeParaAtualizar, filme);
        _context.SaveChanges();

        return NoContent();
    }

    /// <summary>
    /// Deleção completa de um filme no banco de dados
    /// </summary>
    /// <param name="id">ID do filme que deseja deletar</param>    
    /// <returns>IActionResult</returns>
    /// <response code="204">Caso delete o filme com sucessso</response>
    [HttpDelete("{id}")]
    public IActionResult DeletaFilme(int id)
    {
        var filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
        if (filme == null) return NotFound();

        _context.Remove(filme);
        _context.SaveChanges();
        return NoContent();
    }
}
