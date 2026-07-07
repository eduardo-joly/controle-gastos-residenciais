using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MinhaApi.Data;
using MinhaApi.Models;


namespace MinhaApi.Controllers;


[ApiController]
[Route("api/[controller]")]
public class TransacoesController : ControllerBase
{

    private readonly AppDbContext _context;



    public TransacoesController(AppDbContext context)
    {
        _context = context;
    }




    // GET api/Transacoes
    [HttpGet]
    public async Task<ActionResult> GetTransacoes()
    {

        var lista = await _context.Transacoes
            .Include(t => t.Pessoa)
            .Select(t => new
            {
                t.Id,
                t.Descricao,
                t.Valor,
                t.Tipo,
                Pessoa = t.Pessoa!.Nome
            })
            .ToListAsync();


        return Ok(lista);

    }




    // POST api/Transacoes
    [HttpPost]
    public async Task<ActionResult> CriarTransacao(
        Transacao transacao)
    {


        var pessoaExiste =
            await _context.Pessoas
            .AnyAsync(p => p.Id == transacao.PessoaId);



        if(!pessoaExiste)
        {
            return BadRequest(
                "A pessoa informada não existe."
            );
        }



        _context.Transacoes.Add(transacao);


        await _context.SaveChangesAsync();



        return Ok(transacao);

    }




    // PUT api/Transacoes/5
    [HttpPut("{id}")]
    public async Task<IActionResult> Atualizar(
        int id,
        Transacao transacao)
    {


        var atual =
            await _context.Transacoes.FindAsync(id);



        if(atual == null)
        {
            return NotFound();
        }



        atual.Descricao = transacao.Descricao;
        atual.Valor = transacao.Valor;
        atual.Tipo = transacao.Tipo;
        atual.PessoaId = transacao.PessoaId;



        await _context.SaveChangesAsync();



        return NoContent();

    }





    // DELETE api/Transacoes/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> Excluir(int id)
    {


        var transacao =
            await _context.Transacoes.FindAsync(id);



        if(transacao == null)
        {
            return NotFound();
        }



        _context.Transacoes.Remove(transacao);



        await _context.SaveChangesAsync();



        return NoContent();

    }


}