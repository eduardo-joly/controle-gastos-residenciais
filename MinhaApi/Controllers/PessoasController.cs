using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MinhaApi.Data;
using MinhaApi.Models;

namespace MinhaApi.Controllers;


[ApiController]
[Route("api/[controller]")]
public class PessoasController : ControllerBase
{

    private readonly AppDbContext _context;


    public PessoasController(AppDbContext context)
    {
        _context = context;
    }



    // GET api/Pessoas
    [HttpGet]
    public async Task<ActionResult> GetPessoas()
    {

        var pessoas = await _context.Pessoas
            .Select(p => new
            {
                p.Id,
                p.Nome,
                p.Idade
            })
            .ToListAsync();


        return Ok(pessoas);

    }



    // GET api/Pessoas/5
    [HttpGet("{id}")]
    public async Task<ActionResult> GetPessoa(int id)
    {

        var pessoa = await _context.Pessoas
            .Include(p => p.Transacoes)
            .FirstOrDefaultAsync(p => p.Id == id);



        if (pessoa == null)
        {
            return NotFound();
        }


        return Ok(pessoa);

    }




    // POST api/Pessoas
    [HttpPost]
    public async Task<ActionResult<Pessoa>> CriarPessoa(Pessoa pessoa)
    {


        if(string.IsNullOrWhiteSpace(pessoa.Nome))
        {
            return BadRequest("Nome obrigatório");
        }



        _context.Pessoas.Add(pessoa);


        await _context.SaveChangesAsync();



        return CreatedAtAction(
            nameof(GetPessoa),
            new { id = pessoa.Id },
            pessoa
        );

    }




    // PUT api/Pessoas/5
    [HttpPut("{id}")]
    public async Task<IActionResult> AtualizarPessoa(
        int id,
        Pessoa pessoa)
    {


        if(id != pessoa.Id)
        {
            return BadRequest(
                "O ID da URL não corresponde ao ID da pessoa."
            );
        }



        var existe = await _context.Pessoas
            .FindAsync(id);



        if(existe == null)
        {
            return NotFound();
        }



        existe.Nome = pessoa.Nome;
        existe.Idade = pessoa.Idade;



        await _context.SaveChangesAsync();



        return NoContent();

    }





    // DELETE api/Pessoas/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletarPessoa(int id)
    {


        var pessoa = await _context.Pessoas
            .Include(p => p.Transacoes)
            .FirstOrDefaultAsync(p => p.Id == id);



        if(pessoa == null)
        {
            return NotFound();
        }



        _context.Transacoes.RemoveRange(
            pessoa.Transacoes
        );



        _context.Pessoas.Remove(pessoa);



        await _context.SaveChangesAsync();



        return NoContent();

    }

}