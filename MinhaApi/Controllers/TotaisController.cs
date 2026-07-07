using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MinhaApi.Data;

namespace MinhaApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TotaisController : ControllerBase
{
    private readonly AppDbContext _context;


    public TotaisController(AppDbContext context)
    {
        _context = context;
    }


    [HttpGet]
    public async Task<IActionResult> GetTotais()
    {
        var pessoas = await _context.Pessoas
            .Include(p => p.Transacoes)
            .ToListAsync();


        var resultado = pessoas.Select(p => new
        {
            Pessoa = p.Nome,

            TotalReceitas = p.Transacoes
                .Where(t => t.Tipo.ToLower() == "receita")
                .Sum(t => t.Valor),


            TotalDespesas = p.Transacoes
                .Where(t => t.Tipo.ToLower() == "despesa")
                .Sum(t => t.Valor),


            Saldo = p.Transacoes
                .Where(t => t.Tipo.ToLower() == "receita")
                .Sum(t => t.Valor)

                -

                p.Transacoes
                .Where(t => t.Tipo.ToLower() == "despesa")
                .Sum(t => t.Valor)
        });


        return Ok(resultado);
    }
}