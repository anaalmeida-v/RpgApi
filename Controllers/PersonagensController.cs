using Microsoft.AspNetCore.Mvc;

namespace RpgApi.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class PersonagensController : ControllerBase
    {
        private readonly DataContext _context;

        public PersonagensController(DataContext context)
        {
            _context = context;
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetSingle(int id)
    {
        try
        {
            Personagem p = await _context.Personagens
                .FirstOrDefaultAsync(pBusca => pBusca.Id == id);

            return Ok(p);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.message);
        }
    }

    [HttpGet("GetAll")]

    public async Task<IActionResult> Get()
    {
        try
        {
            List<Personagem> lista = await _context.Personagens.ToListAsync();
            return Ok(lista);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.message);
        }
    }

    [HttpPost]

    public async Task<IActionResult> Add(Personagem novoPersonagem)
    {
        try
        {
            if (novoPersonagem.PontosVida > 100)
            {
                throw new Exception("Pontos de vida não pode ser maior que 100");
            }
            await _context.Personagens.AddAsync(novoPersonagem);
            await _context.SaveChangesAsync();

            return Ok(novoPersonagem.Id);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.message);
        }
    }

    [HttpPut]

    public async Task<IActionResult> Update(Personagem novoPersonagem)
    {
        try
        {
            if (novoPersonagem.PontosVida > 100)
            {
                throw new Exception("Pontos de Vida não pode ser maior que 100");
            }
            _context.Personagens.Update(novoPersonagem);
            int linhasAfetadas = await _context.SaveChangesAsync();

            return Ok(linhasAfetadas);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("{Id}")]

    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            Personagem pRemover = await _context.Personagens
            .FirstOrDefaultAsync(p => p.Id == id);

            _context.Personagens.Remove(pRemover);
            int linhasAfetadas = await _context.SaveChangesAsync();

            return Ok(linhasAfetadas);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost("GetUser")]

    public async Task<IActionResult> Get(Usuario u)
    {
        try
        {
            Usuario uRetornado = await _context.Usuarios
                .FirstOrDefaultAsync(x => x.Username == u.Username && u.Email == u.Email);

                if(uRetornado == null)
                    throw new Exception("Usuário não encontrado");

                return Ok(uRetornado);
        }
        catch (System.Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}